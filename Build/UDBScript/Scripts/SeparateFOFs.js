/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Separate FOFs`;

`#description Assign new control sectors to all the FOFs inside the selected sectors so that they can be altered without affecting the original FOFs`;

`#scriptoptions

newTagsOnControlSectors
{
    description = "Whether to assign new tags to the new control sectors";
    type = 3;
}
`;

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

const getSelectedElements = () => {
    const selectedElements = [];

    if (UDB.Map.srb2_visualSelection) {
        UDB.Map.srb2_visualSelection.forEach(element => {
            if (['floor', 'ceiling'].includes(element.type)) {
                element.sector.getTags().forEach(tag => {
                    selectedElements.push({ sector: element.sector, tag });
                });
            } else if (element.type.startsWith('3dfloor')) {
                selectedElements.push({
                    sector: element.sector,
                    tag: element.controlLinedef.args[0]
                });
            }
        });
    } else {
        UDB.Map.getSelectedOrHighlightedSectors().forEach(sector => {
            sector.getTags().forEach(tag => {
                selectedElements.push({ sector, tag });
            });
        });
    }

    return selectedElements;
};

const reassignControlSectorTags = (sector, originalTagToNewTag) => {
    sector.getTags().forEach(originalTag => {
        sector.removeTag(originalTag);

        if (originalTagToNewTag.has(originalTag)) {
            sector.addTag(originalTagToNewTag.get(originalTag));
        } else {
            const tag = UDB.Map.getNewTag();
            sector.addTag(tag);
            originalTagToNewTag.set(originalTag, tag);
        }
    });
};

const fixSlopes = (sector, fofSector, originalSector) => {
    const refPoint = findLeftmostBottommostLineCenterInSector(sector);
    const originalRefPoint = findLeftmostBottommostLineCenterInSector(originalSector);

    const bottomPlane = fofSector.getFloorPlane();
    if (Math.abs(bottomPlane.normal.z - 1) > 0.001) {
        bottomPlane.getZ(refPoint);
        const adjustedHeight = bottomPlane.getZ(originalRefPoint) - bottomPlane.getZ(refPoint);
        fofSector.floorSlopeOffset = getRaisedPlane(bottomPlane, adjustedHeight).offset;
    }

    const topPlane = fofSector.getCeilingPlane();
    if (Math.abs(topPlane.normal.z - -1) > 0.001) {
        topPlane.getZ(refPoint);
        const adjustedHeight = topPlane.getZ(originalRefPoint) - topPlane.getZ(refPoint);
        fofSector.ceilingSlopeOffset = getRaisedPlane(topPlane, adjustedHeight).offset;
    }
};

const selectedElements = getSelectedElements();
if (selectedElements.length === 0)
    UDB.die('No FOFs or sectors selected.');

const selectedSectorsSet = new Set(selectedElements.map(s => s.sector));

const originalTags = new Set();
selectedElements.forEach(element => {
    element.sector.getTags().forEach(tag => {
        if (!originalTags.has(tag))
            originalTags.add(tag);
    });
});

const unusedControlSectors = SRB2ControlSector.sortControlSectors(SRB2ControlSector.findUnusedControlSectors());
if (unusedControlSectors.length < originalTags.size)
    UDB.die('Not enough control sectors available');

const tagToFofLines = new Map();
UDB.Map.getLinedefs().forEach(line => {
    const tag = line.args[0];

    if (tag !== 0 && originalTags.has(tag) && SRB2ControlSector.isFofLine(line)) {
        if (tagToFofLines.has(tag))
            tagToFofLines.get(tag).push(line);
        else
            tagToFofLines.set(tag, [line]);
    }
});

const tagToSectors = new Map();
UDB.Map.getSectors().forEach(sector => {
    sector.getTags().forEach(tag => {
        if (tagToFofLines.has(tag) && !selectedSectorsSet.has(sector)) {
            if (tagToSectors.has(tag))
                tagToSectors.get(tag).push(sector);
            else
                tagToSectors.set(tag, [sector]);
        }
    });
});

let unusedControlSectorIndex = 0;
const originalTagToNewTag = new Map();

UDB.Map.clearAllSelected();

selectedElements.forEach(({ sector, tag: originalTag }) => {
    sector.removeTag(originalTag);

    tagToFofLines.get(originalTag).forEach(originalFofLine => {
        if (originalTagToNewTag.has(originalTag)) {
            sector.addTag(originalTagToNewTag.get(originalTag));
            return;
        }

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

        if (UDB.ScriptOptions.newTagsOnControlSectors)
            reassignControlSectorTags(fofSector, originalTagToNewTag);

        fofLine.front.middleTexture = originalFofLine.front.middleTexture;

        if (tagToSectors.has(originalTag))
            fixSlopes(sector, fofSector, tagToSectors.get(originalTag)[0]);

        fofSector.floorSelected = true;
        fofLine.front.middleSelected = true;
        fofSector.ceilingSelected = true;
    });
});
