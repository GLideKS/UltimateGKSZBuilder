/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Add edge texture`;

`#description Add edge textures to selected sidedefs or linedefs. Choose a blank texture to ignore, "-" to delete.`;

`#scriptoptions

interactive
{
    description = "Interactive (opens a window)";
    type = 3;
    default = false;
}

upperTexture
{
    description = "Upper texture to use";
    type = 6;
}

lowerTexture
{
    description = "Lower texture to use";
    type = 6;
}
`;

const getSelectedElements = () => {
    const selectedElements = [];

    if (UDB.Map.srb2_visualSelection) {
        UDB.Map.srb2_visualSelection.forEach(element => {
            if (element.type === 'side_upper') {
                selectedElements.push({ part: "upper", side: element.sidedef });
                if (element.sidedef.other)
                    selectedElements.push({ part: "upper", side: element.sidedef.other });
            } else if (element.type === 'side_middle') {
                selectedElements.push({ part: "middle", side: element.sidedef });
                if (element.sidedef.other)
                    selectedElements.push({ part: "middle", side: element.sidedef.other });
            } else if (element.type === 'side_lower') {
                selectedElements.push({ part: "lower", side: element.sidedef });
                if (element.sidedef.other)
                    selectedElements.push({ part: "lower", side: element.sidedef.other });
            } else if (element.type === '3dfloor_side') {
                selectedElements.push({ part: "middle", side: element.controlLinedef.front });
            }
        });
    } else {
        UDB.Map.getSelectedOrHighlightedLinedefs().forEach(line => {
            if (line.back) {
                selectedElements.push({ part: 'lower', side: line.front });
                selectedElements.push({ part: 'lower', side: line.back });
            }
            else {
                selectedElements.push({ part: 'lower', side: line.front });
            }
        });
    }

    return selectedElements;
};

const queryOptions = () => {
    const options = new UDB.QueryOptions();

    options.addOption('upperTexture', 'Upper texture', 6, UDB.ScriptOptions.upperTexture);
    options.addOption('lowerTexture', 'Lower texture', 6, UDB.ScriptOptions.lowerTexture);

    if (!options.query())
        UDB.exit();

    UDB.ScriptOptions.upperTexture = options.options.upperTexture;
    UDB.ScriptOptions.lowerTexture = options.options.lowerTexture;
};

const selectedElements = getSelectedElements();
if (selectedElements.length === 0)
    UDB.die('No sidedefs or linedefs selected');

if (UDB.ScriptOptions.interactive)
    queryOptions();

UDB.ScriptOptions.upperTexture = UDB.ScriptOptions.upperTexture.trim();
UDB.ScriptOptions.lowerTexture = UDB.ScriptOptions.lowerTexture.trim();

const upperTexture = UDB.ScriptOptions.upperTexture === '-' ? null : UDB.ScriptOptions.upperTexture;
const lowerTexture = UDB.ScriptOptions.lowerTexture === '-' ? null : UDB.ScriptOptions.lowerTexture;

const ignoreUpper = (upperTexture === '');
const ignoreLower = (lowerTexture === '');

selectedElements.forEach(element => {
    const fields = element.side.fields;

    if (element.part === 'upper') {
        if (!ignoreUpper)
            fields.edge_top_upper_texture = upperTexture;
        if (!ignoreLower)
            fields.edge_top_lower_texture = lowerTexture;
    } else if (element.part === 'middle') {
        if (!ignoreUpper)
            fields.edge_top_upper_texture = upperTexture;
        if (!ignoreLower)
            fields.edge_bottom_lower_texture = lowerTexture;
    } else if (element.part === 'lower') {
        if (!ignoreUpper)
            fields.edge_bottom_upper_texture = upperTexture;
        if (!ignoreLower)
            fields.edge_bottom_lower_texture = lowerTexture;
    }
});
