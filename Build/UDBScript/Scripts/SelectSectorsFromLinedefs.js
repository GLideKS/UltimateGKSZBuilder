/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select sectors from linedefs`;

`#description Select all sectors touching the front sides of the selected linedefs`;

let lines = UDB.Map.getSelectedOrHighlightedLinedefs();
if (lines.length === 0)
    UDB.die('No linedefs selected');

lines.forEach(line => {
    line.front?.sector.selected = true;
});
