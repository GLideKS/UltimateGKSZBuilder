/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select all sectors that use equation slopes on the floor or ceiling`;

let sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    sectors = UDB.Map.getSectors();

UDB.Map.clearAllSelected();

sectors.forEach(sector => {
    if (
        (Math.abs(sector.getFloorSlope().getLength() - 1) < 0.001 && Math.abs(sector.getFloorSlope().z - 1) > 0.001) ||
        (Math.abs(sector.getCeilingSlope().getLength() - 1) < 0.001 && Math.abs(sector.getCeilingSlope().z - -1) > 0.001)
    )
		sector.selected = true;
});
