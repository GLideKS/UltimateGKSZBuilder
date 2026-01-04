/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select control sectors only`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

UDB.Map.clearAllSelected();

sectors.forEach(sector => {
    if (SRB2ControlSector.isFofSector(sector))
        sector.selected = true;
});
