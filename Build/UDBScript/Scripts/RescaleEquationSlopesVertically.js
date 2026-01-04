/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Rescale equation slopes vertically`;

`#scriptoptions

scale
{
    description = "Scaling factor";
    default = 1.0;
    type = 1;
}
`;

const getVerticesInSector = (sector) => {
    const vertices = [];

    sector.getSidedefs()
        .map(s => s.line)
        .filter(l => l.front !== l.back)
        .forEach(line => {
            if (!vertices.includes(line.start))
                vertices.push(line.start);
            if (!vertices.includes(line.end))
                vertices.push(line.end);
        });

    return vertices;
};

const rescalePlaneVertically = (plane, vertices, up) => {
    const points = vertices.slice(0, 3).map(v => new UDB.Vector3D(v.position.x, v.position.y, plane.getZ(v.position)));
    const newPoints = points.map(p => [p.x, p.y, p.z * scale]);
    return new UDB.Plane(newPoints[0], newPoints[1], newPoints[2], up);
};

const findFirstTargetSector = (sector) => {
    for (side of sector.getSidedefs()) {
        if (SRB2ControlSector.isFofLine(side.line)) {
            const targetSectors = tagToSectors.get(side.line.args[0]);
            if (targetSectors)
                return targetSectors[0];
        }
    }

    return null;
};

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

const scale = UDB.ScriptOptions.scale;

const tagToSectors = new Map();
UDB.Map.getSectors().forEach(sector => {
    sector.getTags().forEach(tag => {
        if (tagToSectors.has(tag))
            tagToSectors.get(tag).push(sector);
        else
            tagToSectors.set(tag, [sector]);
    });
});

sectors.forEach(sector => {
    const vertices = getVerticesInSector(findFirstTargetSector(sector) ?? sector);
    if (vertices.length < 3)
        return;

    if (Math.abs(sector.getFloorSlope().getLength() - 1) < 0.001) {
        newFloorPlane = rescalePlaneVertically(new UDB.Plane(sector.getFloorSlope(), sector.floorSlopeOffset), vertices, true);
        sector.setFloorSlope(newFloorPlane.normal);
        sector.floorSlopeOffset = newFloorPlane.offset;
    }

    if (Math.abs(sector.getCeilingSlope().getLength() - 1) < 0.001) {
        newCeilingPlane = rescalePlaneVertically(new UDB.Plane(sector.getCeilingSlope(), sector.ceilingSlopeOffset), vertices, false);
        sector.setCeilingSlope(newCeilingPlane.normal);
        sector.ceilingSlopeOffset = newCeilingPlane.offset;
    }
});
