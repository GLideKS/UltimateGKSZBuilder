/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Delete grass edge`;

`#description Delete grass edges from selected linedefs`;

const lines = UDB.Map.getSelectedOrHighlightedLinedefs();
if (lines.length === 0)
    UDB.die('No linedefs selected');

lines.forEach(line => {
    if (!line.back)
        return;

    line.flags.midpeg = false;
    line.flags.midsolid = false;
    line.flags.noskew = false;
    line.flags.wrapmidtex = false;

    line.front.middleTexture = '-';
    line.back.middleTexture = '-';
});
