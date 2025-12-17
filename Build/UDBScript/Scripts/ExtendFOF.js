/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Extend FOFs`;

`#description Applies the first selected FOF (or FOFs contained in the first selected sector) to the rest of the selection`;

// Todo:
// Only copy FOF tags

const getSelectedElements = () => {
    let tags;
    let targetSectors = [];
    let targetFofs = [];

    const visualSelection = UDB.Map.srb2_visualSelection;

    if (visualSelection) {
        if (visualSelection.length !== 0) {
            const firstElement = visualSelection[0];

            if (['floor', 'ceiling'].includes(firstElement.type))
                tags = firstElement.sector.getTags();
            else if (firstElement.type.startsWith('3dfloor'))
                tags = [firstElement.controlLinedef.args[0]];
        }

        visualSelection.slice(1).forEach(element => {
            if (['floor', 'ceiling'].includes(element.type)) {
                targetSectors.push(element.sector);
            } else if (element.type.startsWith('3dfloor')) {
                targetFofs.push({
                    sector: element.sector,
                    tag: element.controlLinedef.args[0]
                });
            }
        });

        if (!tags || (targetSectors.length === 0 && targetFofs.length === 0))
            UDB.die('No FOF or sector selected. Select the FOF or sector to be extended and at least one target FOF or sector.');
    } else {
        const sectors = UDB.Map.getSelectedOrHighlightedSectors();
        if (sectors.length < 2)
            UDB.die('Not enough sectors selected. Select the sector containing the FOFs to be extended and at least one target sector.');

        tags = sectors[0].getTags();
        targetSectors = sectors.slice(1);
    }

    return [tags, targetSectors, targetFofs];
};

const [tags, targetSectors, targetFofs] = getSelectedElements();

targetSectors.forEach(targetSector => {
    tags.forEach(t => targetSector.addTag(t));
});

targetFofs.forEach(({ sector: targetSector, tag: targetTag }) => {
    targetSector.removeTag(targetTag);
    tags.forEach(t => targetSector.addTag(t));
});
