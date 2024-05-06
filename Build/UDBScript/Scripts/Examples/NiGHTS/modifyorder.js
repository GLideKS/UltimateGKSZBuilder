/// <reference path="../../udbscript.d.ts" />

`#version 4`;

`#name Modify NiGHTS track order`;

`#description Inserts or removes an order index from the selected thing's mare`;

`#scriptoptions

operation
{
	description = "Insert/remove?";
	default = 0;
	type = 11; // Enum
	enumvalues {
		0 = "Insert";
		1 = "Remove";
	}
}
`;

// Get the selected things
let selected = UDB.Map.getSelectedThings();

if (selected.length != 1)
    UDB.die('More than one thing selected, aborting script.');

if (selected[0].type < 1700 || selected[0].type > 1702)
	UDB.die('Thing is not a track element, aborting script.');

let mare = selected[0].args[0];
let order = selected[0].args[1];
let operation = UDB.ScriptOptions.operation;

UDB.Map.getThings().filter(o => o.type >= 1700 && o.type <= 1702).forEach(thing => {

	if (thing.args[0] == mare)
	{
		if (operation == 0 && thing.args[1] > order)
			thing.args[1] = thing.args[1] + 1;
		else if (operation == 1 && thing.args[1] > order)
			thing.args[1] = thing.args[1] - 1;
		else if (operation == 1 && thing.args[1] == order)
			thing.delete();
	}

});