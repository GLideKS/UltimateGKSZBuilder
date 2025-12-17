/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Change UDMF field by relative amount`;

`#description Add a relative amount to an arbitrary UDMF field of selected map elements`;

`#scriptoptions

field
{
    description = "Field name";
    type = 2;
}

amount
{
    description = "Amount to add";
    type = 0;
}
`;

const field = UDB.ScriptOptions.field;

for (const list of [
    UDB.Map.getSelectedOrHighlightedSectors(),
    UDB.Map.getSelectedOrHighlightedLinedefs(),
    UDB.Map.getSelectedOrHighlightedVertices(),
    UDB.Map.getSelectedOrHighlightedThings(),
]) {
    if (list.length !== 0) {
        list.forEach(element => {
            UDB.log(element);
            if (element.fields[field])
                element.fields[field] += UDB.ScriptOptions.amount;
        });
        break;
    }
}
