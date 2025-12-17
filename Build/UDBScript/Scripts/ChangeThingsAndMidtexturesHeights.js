/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Change things and midtextures heights`;

`#description Change things and midtextures heights`;

`#scriptoptions

heightDelta
{
    description = "Height change";
    type = 0;
}
`;

const midtexturesToChange = [
    'OLDGFZF3',
    'OLDGFZG1',
    'OLDGFZG2',
    'OLDGFZG3',
    'OLDGFZG4',
];


const things = UDB.Map.getSelectedOrHighlightedThings();
const sides = UDB.Map.getSidedefsFromSelectedOrHighlightedLinedefs();
if (things.length === 0 && sides.length === 0)
    UDB.die('No things or sidedefs selected');

things.forEach(thing => {
    thing.position.z += UDB.ScriptOptions.heightDelta;
});

sides.forEach(side => {
    if (midtexturesToChange.includes(side.middleTexture))
        side.fields.offsety_mid = (side.fields.offsety_mid ?? 0) + UDB.ScriptOptions.heightDelta;
});
