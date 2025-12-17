/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Mirror slope`;

`#description Mirror a sector's ceiling slope to its floor.`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

sectors.forEach(sector => {
    const slope = sector.getFloorSlope();
    sector.setCeilingSlope([slope.x, slope.y, -slope.z]);
    sector.ceilingSlopeOffset = sector.floorSlopeOffset;
});
