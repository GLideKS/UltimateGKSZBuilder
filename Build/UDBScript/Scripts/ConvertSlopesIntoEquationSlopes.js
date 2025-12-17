/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Convert slopes to equation slopes`;

`#description Convert all slopes in selected sectors to equation slopes. Also clears linedef actions in most cases. Dynamic slopes are skipped.`;

const isSectorSlopeSide = (side) => {
    const pertinentArg = side.isFront ? 1 : 2;

    return side.line.action === 700 &&
        (side.line.args[0] === pertinentArg || side.line.args[1] === pertinentArg);
};

const isVertexSlopeSide = (side) =>
    side.line.action === 704 && ((side.line.args[0] < 2) ? side.isFront : !side.isFront);

const isCopySlopeSide = (side) =>
    side.line.action === 720;

const findSectorByTag = (tag) =>
    tag !== 0 ? UDB.Map.getSectors().find(s => s.getTags().includes(tag)) : undefined;

const findSectorPlanes = (sector) => {
    let floorPlane = sector.getFloorPlane();
    let ceilingPlane = sector.getCeilingPlane();

    sector.getSidedefs().forEach(side => {
        const args = side.line.args;

        if (isVertexSlopeSide(side)) {
            const vertexTags = [args[1], args[2], args[3]];

            const vertexThings = [];
            vertexTags.forEach(tag => {
                const thing = UDB.Map.getThings().find(t => t.tag === tag && !vertexThings.includes(t));
                if (thing)
                    vertexThings.push(thing);
            });

            if (vertexThings.length !== 3)
                return;

            const vertexPositions = vertexThings.map(thing => [
                thing.position.x,
                thing.position.y,
                thing.position.z + (thing.args[0] === 0 ? thing.getSector().floorHeight : 0)
            ]);

            const forFloor = (args[0] % 2 === 0);
            const plane = new UDB.Plane(vertexPositions[0], vertexPositions[1], vertexPositions[2], forFloor);
            if (forFloor)
                floorPlane = plane;
            else
                ceilingPlane = plane;
        } else if (isCopySlopeSide(side)) {
            const argOffset = side.isFront ? 0 : 2;
            const floorTag = args[0 + argOffset];
            const ceilingTag = args[1 + argOffset];

            const floorSector = findSectorByTag(floorTag);
            const ceilingSector = findSectorByTag(ceilingTag);

            if (floorSector)
                floorPlane = floorSector.getFloorPlane();
            if (ceilingSector)
                ceilingPlane = ceilingSector.getCeilingPlane();
        }
    });

    return [floorPlane, ceilingPlane];
};

const clearAction = (line) => {
    line.action = 0;

    for (let i = 0; i < line.args.length; i++)
        line.args[i] = 0;
};

let sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

sectors = sectors.filter(sector => !sector.getSidedefs().some(side =>
    (isSectorSlopeSide(side) && (side.line.args[2] & 2)) ||
    (isVertexSlopeSide(side) && (side.line.args[4] & 2))
));

sectors.forEach(sector => {
    const [floorPlane, ceilingPlane] = findSectorPlanes(sector);

    if (Math.abs(floorPlane.normal.z - 1) > 0.001) {
        sector.setFloorSlope(floorPlane.normal);
        sector.floorSlopeOffset = floorPlane.offset;
    } else {
        sector.floorHeight = -floorPlane.offset;
    }

    if (Math.abs(ceilingPlane.normal.z - 1) > 0.001) {
        sector.setCeilingSlope(ceilingPlane.normal);
        sector.ceilingSlopeOffset = ceilingPlane.offset;
    } else {
        sector.ceilingHeight = ceilingPlane.offset;
    }
});

// Cleanup linedef actions for simple cases
sectors.forEach(sector => {
    sector.getSidedefs().forEach(side => {
        const args = side.line.args;

        if (isSectorSlopeSide(side) && !(args[2] & 4)) {
            const pertinentArg = side.isFront ? 1 : 2;

            // Floor
            if (args[0] === pertinentArg)
                args[0] = 0;

            // Ceiling
            if (args[1] === pertinentArg)
                args[1] = 0;

            if (args[0] === 0 && args[1] === 0)
                clearAction(side.line);
        } else if (isCopySlopeSide(side) && args[4] === 0) {
            const argOffset = side.isFront ? 0 : 2;

            // Floor
            if (args[0 + argOffset] !== 0)
                args[0 + argOffset] = 0;

            // Ceiling
            if (args[1 + argOffset] !== 0)
                args[1 + argOffset] = 0;

            if (args[0] === 0 && args[1] === 0 && args[2] === 0 && args[3] === 0)
                clearAction(side.line);
        } else if (isVertexSlopeSide(side)) {
            clearAction(side.line);
        }
    });
});
