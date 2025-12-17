/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Rotate things vertically`;

`#description Rotate things vertically`;

const things = UDB.Map.getSelectedOrHighlightedThings();
if (things.length === 0)
    UDB.die('No things selected');

things.forEach(thing => {
    const p = thing.position;
    thing.position = [-p.z - thing.getSector().floorHeight, p.y, p.x];
});
