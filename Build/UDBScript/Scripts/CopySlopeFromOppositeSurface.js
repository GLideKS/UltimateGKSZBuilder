/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Copy slope from opposite surface`;

`#scriptoptions

surfaceType
{
	description = "Affected surface type";
	default = 0;
	type = 11; // Enum
	enumvalues {
		0 = "Floor";
		1 = "Ceiling";
	}
}
`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

sectors.forEach(sector => {
	if (UDB.ScriptOptions.surfaceType == 0) {
		const slope = sector.getCeilingSlope();
		sector.setFloorSlope([-slope.x, -slope.y, -slope.z]);
		sector.floorSlopeOffset = -sector.ceilingSlopeOffset;
		sector.floorHeight = sector.ceilingHeight;
	} else {
		const slope = sector.getFloorSlope();
		sector.setCeilingSlope([-slope.x, -slope.y, -slope.z]);
		sector.ceilingSlopeOffset = -sector.floorSlopeOffset;
		sector.ceilingHeight = sector.floorHeight;
	}
});
