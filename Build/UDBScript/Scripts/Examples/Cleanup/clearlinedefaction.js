/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Reset linedef actions`;

`#description Resets the action of all selected linedefs to 0.`;

UDB.Map.getSelectedOrHighlightedLinedefs().forEach(line => {
	if (line.action > 0) {
		line.action = 0;
	}
});
