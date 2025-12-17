/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Clone FOF`;

`#description Clone a FOF into the selected sectors`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

const lines = UDB.Map.getSelectedOrHighlightedLinedefs();
if (lines.length === 0)
    UDB.die('No FOF selected. Select the side of the FOF to be cloned.');
if (lines.length > 1)
    UDB.die('More than one FOF selected.');
const originalFofLine = lines[0];
const originalFofSector = originalFofLine.front.sector;

const controlSectors = SRB2ControlSector.sortControlSectors(SRB2ControlSector.findUnusedControlSectors());
if (controlSectors.length < sectors.length)
    UDB.die('Not enough control sectors available');

UDB.Map.clearAllSelected();

sectors.forEach((sector, i) => {
    if (SRB2ControlSector.isFofSector(sector))
        return;

    const fofSector = controlSectors[i];
    const fofLines = fofSector.getSidedefs().map(s => s.line);
    const fofLine = SRB2ControlSector.findBestControlLine(fofLines);

    const tag = UDB.Map.getNewTag();

    sector.addTag(tag);

    originalFofLine.copyPropertiesTo(fofLine);
    originalFofSector.copyPropertiesTo(fofSector);
    fofLine.args[0] = tag;

    fofLine.front.middleTexture = originalFofLine.front.middleTexture;

    fofSector.floorSelected = true;
    fofLine.front.middleSelected = true;
    fofSector.ceilingSelected = true;
});
