/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Clear linedef midtextures`;

`#description Clears all midtextures from two-sided linedefs, and optionally removes all flags related to them (Peg Midtexture, Solid Midtexture, Repeat Midtexture)`;

`#scriptoptions

clearflags
{
	description = "Remove midtexture-related flags";
	default = true;
	type = 3; // Boolean
}
`;

UDB.Map.getSelectedOrHighlightedLinedefs().forEach(line => {
	if (line.front != null && line.back != null) {
		line.front.middleTexture = "-";
		line.back.middleTexture = "-";
		
		if (UDB.ScriptOptions.clearflags) {
			line.flags['midpeg'] = false;
			line.flags['midsolid'] = false;
			line.flags['wrapmidtex'] = false;
		}
	}
});
