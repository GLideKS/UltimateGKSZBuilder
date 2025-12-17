/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Increment tag`;

`#description Increment or decrement all tags and ID arguments in selected elements`;

`#scriptoptions

tag
{
    description = "Value to add";
    type = 0;
}
`;

const lineArgsWithSectorIDs = new Map([
    [6, [0]],
    [7, [0]],
    [10, [0]],
    [63, [0]],
    [8, [0]],
    [64, [1]],
    [53, [0]],
    [56, [0]],
    [60, [0]],
    [61, [0]],
    [66, [0]],
    [100, [0]],
    [120, [0]],
    [150, [0]],
    [160, [0]],
    [170, [0]],
    [190, [0]],
    [200, [0]],
    [202, [0]],
    [220, [0]],
    [223, [0]],
    [250, [0]],
    [251, [0]],
    [254, [0]],
    [257, [0]],
    [258, [0]],
    [259, [0]],
    [313, [0]],
    [400, [0]],
    [402, [0]],
    [408, [0]],
    [409, [0, 1]],
    [410, [0]],
    [416, [0]],
    [417, [0]],
    [418, [0]],
    [420, [0]],
    [421, [0]],
    [435, [0]],
    [467, [0]],
    [469, [0]],
    [403, [0]],
    [405, [0]],
    [411, [0]],
    [428, [0]],
    [429, [0]],
    [442, [0]],
    [414, [2]],
    [436, [0, 1]],
    [445, [0, 1]],
    [446, [0, 1]],
    [447, [0, 1]],
    [452, [0, 1]],
    [453, [0, 1]],
    [454, [0, 1]],
    [455, [0, 1]],
    [456, [0]],
    [510, [0]],
    [541, [0]],
    [600, [0]],
    [602, [0]],
    [603, [0]],
    [604, [0]],
    [606, [0, 1]],
    [720, [0, 1, 2, 3]],
]);

const lineArgsWithLineIDs = new Map([
    [64, [0]],
    [20, [4]],
    [70, [0]],
    [71, [0]],
    [72, [0]],
    [73, [0]],
    [74, [0, 3]],
    [75, [0]],
    [76, [0]],
    [254, [5]],
    [403, [3]],
    [457, [3]],
    [439, [0]],
    [450, [0]],
    [451, [0, 0]],
    [459, [3]],
    [465, [0]],
    [468, [0]],
    [502, [0]],
]);

const lineArgsWithThingIDs = new Map([
    [20, [0, 1]],
    [30, [0]],
    [31, [0]],
    [32, [0]],
    [412, [0]],
    [457, [0]],
    [464, [0]],
    [422, [0]],
    [480, [0]],
    [481, [0]],
    [482, [0]],
    [484, [0]],
    [488, [0]],
    [489, [0]],
    [491, [0]],
    [492, [0]],
    [704, [1, 2, 3]],
]);

const lineArgsWithIDs = [
    lineArgsWithSectorIDs,
    lineArgsWithLineIDs,
    lineArgsWithThingIDs,
];

const thingArgsWithLineIDs = new Map([
    [110, [0]],
    [200, [2, 3, 4]],
    [201, [2, 3, 4]],
    [202, [2, 3, 4]],
    [203, [2, 3, 4, 5]],
    [204, [2, 3, 4]],
    [206, [2, 3, 4, 5]],
    [208, [2, 3, 4]],
    [209, [2, 3, 4, 5]],
    [400, [0]],
    [401, [0]],
    [402, [0]],
    [403, [0]],
    [404, [0]],
    [405, [0]],
    [406, [0]],
    [407, [0]],
    [408, [0]],
    [409, [0]],
    [410, [0]],
    [411, [0]],
    [413, [0]],
    [414, [0]],
    [415, [0]],
    [416, [0]],
    [418, [0]],
    [419, [0]],
    [420, [0]],
    [421, [0]],
    [422, [0]],
    [431, [0]],
    [432, [0]],
    [433, [0]],
    [434, [0]],
    [435, [0]],
    [436, [0]],
    [437, [0]],
    [438, [0]],
    [440, [0]],
    [443, [0]],
    [450, [0]],
    [451, [0]],
    [452, [0]],
    [756, [0]],
    [757, [6]],
    [1806, [0]],
    [1807, [0]],
]);

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
const lines = UDB.Map.getSelectedOrHighlightedLinedefs();
const things = UDB.Map.getSelectedOrHighlightedThings();
if (sectors.length + lines.length + things.length === 0)
    UDB.die('No map elements selected');

// Sector and line tags
[...sectors, ...lines].forEach(element => {
    const oldTags = element.getTags().filter(t => t > 0);
    oldTags.forEach(t => element.removeTag(t));
    oldTags.forEach(t => element.addTag(t + UDB.ScriptOptions.tag));
});

// Thing tags
things.forEach(thing => {
    if (thing.tag > 0)
        thing.tag += UDB.ScriptOptions.tag;
});

// Line ID arguments
lines.forEach(line => {
    lineArgsWithIDs.forEach(allArgs => {
        const args = allArgs.get(line.action);
        args?.forEach(arg => {
            if (line.args[arg] > 0)
                line.args[arg] += UDB.ScriptOptions.tag;
        });
    });
});

// Thing ID arguments
things.forEach(thing => {
    const args = thingArgsWithLineIDs.get(thing.type);
    args?.forEach(arg => {
        if (thing.args[arg] > 0)
            thing.args[arg] += UDB.ScriptOptions.tag;
    });
});
