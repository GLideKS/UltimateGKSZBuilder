/// <reference path="../../udbscript.d.ts" />

`#version 4`;

`#name Copy plane texture properties to opposite plane`;

`#description Copies plane texture properties (rotation, offsets) of all selected sectors to its opposite plane.`;

`#scriptoptions

direction
{
	description = "Copy direction";
	default = 0;
	type = 11; // Enum
	enumvalues {
		0 = "Floor to ceiling";
		1 = "Ceiling to floor";
	}
}

copytexture
{
	description = "Copy texture?";
	default = 0;
	type = 11; // Enum
	enumvalues {
		0 = "No";
		1 = "Yes";
	}
}
`;

// Get the selected things
let selected = UDB.Map.getSelectedSectors();

if (selected.length == 0)
    UDB.die('This script requires a selection!');

let direction = UDB.ScriptOptions.direction;
let copytexture = UDB.ScriptOptions.copytexture;

UDB.Map.getSelectedSectors().forEach(sector => {
	if (direction == 0)
	{
		sector.fields.xpanningceiling = sector.fields.xpanningfloor;
		sector.fields.ypanningceiling = sector.fields.ypanningfloor;
		sector.fields.rotationceiling = sector.fields.rotationfloor;
		if (copytexture == 1) sector.ceilingTexture = sector.floorTexture;
	}
	else
	{
		sector.fields.xpanningfloor = sector.fields.xpanningceiling;
		sector.fields.ypanningfloor = sector.fields.ypanningceiling;
		sector.fields.rotationfloor = sector.fields.rotationceiling;
		if (copytexture == 1) sector.floorTexture = sector.ceilingTexture;
	}

});