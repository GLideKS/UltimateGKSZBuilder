/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Separate FOFs (old)`;

`#description Assign new control sectors to all the FOFs inside the selected sectors so that they can be altered without affecting the original FOFs`;

const getRaisedPlane = (plane, delta) =>
    new UDB.Plane(plane.normal, plane.offset - plane.normal.z * delta);

const getRaisedSectorSlope = (slope, slopeOffset, delta) =>
    slopeOffset - slope.z * delta;

const findLeftmostBottommostLineCenterInSector = (sector) => {
    let bestCenter = new UDB.Vector2D(Number.MAX_VALUE, Number.MAX_VALUE);

    sector.getSidedefs().forEach(side => {
        const center = side.line.getCenterPoint();

        if (center.x < bestCenter.x || (center.x === bestCenter.x && center.y < bestCenter.y))
            bestCenter = center;
    });

    return bestCenter;
};

const fixSlopes = (sector, fofSector, originalSector) => {
    const refPoint = findLeftmostBottommostLineCenterInSector(sector);
    const originalRefPoint = findLeftmostBottommostLineCenterInSector(originalSector);

    const bottomPlane = fofSector.getFloorPlane();
    if (Math.abs(bottomPlane.normal.z, 1) > 0.001) {
        bottomPlane.getZ(refPoint);
        const adjustedHeight = bottomPlane.getZ(originalRefPoint) - bottomPlane.getZ(refPoint);
        fofSector.floorSlopeOffset = getRaisedPlane(bottomPlane, adjustedHeight).offset;
    }

    const topPlane = fofSector.getCeilingPlane();
    if (Math.abs(topPlane.normal.z, 1) > 0.001) {
        topPlane.getZ(refPoint);
        const adjustedHeight = topPlane.getZ(originalRefPoint) - topPlane.getZ(refPoint);
        fofSector.ceilingSlopeOffset = getRaisedPlane(topPlane, adjustedHeight).offset;
    }
};

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

const originalTags = new Set();
sectors.forEach(sector => {
    sector.getTags().forEach(tag => {
        if (!originalTags.has(tag))
            originalTags.add(tag);
    });
});

const unusedControlSectors = SRB2ControlSector.sortControlSectors(SRB2ControlSector.findUnusedControlSectors());
if (unusedControlSectors.length < originalTags.size)
    UDB.die('Not enough control sectors available');

const originalTagToFofLines = new Map();
UDB.Map.getLinedefs().forEach(line => {
    const tag = line.args[0];

    if (originalTags.has(tag) && SRB2ControlSector.isFofLine(line)) {
        if (originalTagToFofLines.has(tag))
            originalTagToFofLines.get(tag).push(line);
        else
            originalTagToFofLines.set(tag, [line]);
    }
});

const originalTagToSectors = new Map();
UDB.Map.getSectors().forEach(sector => {
    sector.getTags().forEach(tag => {
        if (originalTagToFofLines.has(tag) && !sectors.includes(sector)) {
            if (originalTagToSectors.has(tag))
                originalTagToSectors.get(tag).push(sector);
            else
                originalTagToSectors.set(tag, [sector]);
        }
    });
});

let unusedControlSectorIndex = 0;
const originalTagToNewTag = new Map();

UDB.Map.clearAllSelected();

sectors.forEach(sector => {
    if (SRB2ControlSector.isFofSector(sector))
        return;

    sector.getTags().forEach(originalTag => {
        if (!originalTagToFofLines.has(originalTag))
            return;

        sector.removeTag(originalTag);

        if (originalTagToNewTag.has(originalTag)) {
            sector.addTag(originalTagToNewTag.get(originalTag));
            return;
        }

        originalTagToFofLines.get(originalTag).forEach(originalFofLine => {
            const originalFofSector = originalFofLine.front.sector;

            const fofSector = unusedControlSectors[unusedControlSectorIndex];
            const fofLines = fofSector.getSidedefs().map(s => s.line);
            const fofLine = SRB2ControlSector.findBestControlLine(fofLines);
            unusedControlSectorIndex++;

            const tag = UDB.Map.getNewTag();
            originalTagToNewTag.set(originalTag, tag);

            sector.addTag(tag);

            originalFofLine.copyPropertiesTo(fofLine);
            originalFofSector.copyPropertiesTo(fofSector);
            fofLine.args[0] = tag;

            fofLine.front.middleTexture = originalFofLine.front.middleTexture;

            if (originalTagToSectors.has(originalTag))
                fixSlopes(sector, fofSector, originalTagToSectors.get(originalTag)[0]);

            fofSector.floorSelected = true;
            fofLine.front.middleSelected = true;
            fofSector.ceilingSelected = true;
        });
    });
});
