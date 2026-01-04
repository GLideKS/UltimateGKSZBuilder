/// <reference path="../../../udbscript.d.ts" />

`#version 5`;

`#name Create PolyObjects`;

`#description Creates polyobjects from one more more selected lines. If more than one line is selected, the first will be the parent polyobject and the others will be its children. The anchor will be placed at the mouse cursor.`;

// Check if the mouse is in the map
if (!UDB.Map.mousePosition.isFinite())
	UDB.die('Mouse cursor is not at a valid map position');

// Get the mouse position in the map, snapped to the grid
const cursorPos = UDB.Map.snappedToGrid(UDB.Map.mousePosition);

// Get selected linedefs
const lines = UDB.Map.getSelectedLinedefs();

// Make sure at least one linedef is selected
if (lines.length === 0)
	UDB.die('No linedefs selected');

// This stores polyobject IDs that are already used
const usedIDs = UDB.Map.getThings()
	.filter(t => t.type >= 760 && t.type <= 761)
	.map(t => t.tag);
const usedIDsSet = new Set(usedIDs);

let parentPolyobjectID = null;

lines.forEach(line => {
	// Find the first free polyobject ID
	let polyobjectID = 1;
	while (usedIDsSet.has(polyobjectID))
		polyobjectID++;

	usedIDsSet.add(polyobjectID);

	// Set the line action and argument, and get the position where the
	// polyobject anchor thing will be placed
	line.action = 20; // Polyobject Start Line
	line.args[0] = polyobjectID;
	const anchorPos = line.line.getCoordinatesAt(0.5); // Center of line

	// Set the parent ID
	if (parentPolyobjectID === null)
		parentPolyobjectID = polyobjectID;
	else
		line.args[1] = parentPolyobjectID;

	// Create the polyobject spawn point thing
	const spawnPoint = UDB.Map.createThing(cursorPos, 761); // 761 = Polyobject Spawn Point
	spawnPoint.tag = polyobjectID;

	// Create the polyobject anchor thing
	const anchor = UDB.Map.createThing(anchorPos, 760); // 760 = Polyobject Anchor
	anchor.tag = polyobjectID
});
