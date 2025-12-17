/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Add grass edges`;

`#description Add grass edges to selected linedefs`;

`#scriptoptions

texture
{
    description = "Texture to use";
    type = 6;
}

solid
{
    description = "Whether to set the Solid Midtexture flag";
    type = 3;
}
`;

const lines = UDB.Map.getSelectedOrHighlightedLinedefs();
if (lines.length === 0)
    UDB.die('No linedefs selected');

lines.forEach(line => {
    line.flags.midpeg = true;

	if (UDB.ScriptOptions.solid)
		line.flags.midsolid = true;

    line.front.middleTexture = UDB.ScriptOptions.texture;
    line.back?.middleTexture = UDB.ScriptOptions.texture;
});
