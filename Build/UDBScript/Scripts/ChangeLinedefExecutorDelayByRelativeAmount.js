/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Change linedef executor delay by relative amount`;

`#description Add a relative amount to the executor delay of selected linedefs`;

`#scriptoptions

amount
{
    description = "Delay to add";
    type = 0;
}
`;

const lines = UDB.Map.getSelectedOrHighlightedLinedefs();
if (lines.length === 0)
    UDB.die('No linedefs selected');

lines.forEach(line => {
    line.fields['executordelay'] += UDB.ScriptOptions.amount;
});
