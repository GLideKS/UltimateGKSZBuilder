/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Cleanup unused tags`;

`#description Remove unused tags and linedef actions. Keep in mind seemingly unused tags may be used by external scripts, so use with caution!`;

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

const clearableLineActions = new Set([
    2,
    8,
    10,
    52,
    53,
    56,
    60,
    61,
    63,
    64,
    66,
    70,
    71,
    72,
    73,
    74,
    75,
    76,
    100,
    120,
    150,
    160,
    170,
    190,
    200,
    202,
    220,
    223,
    250,
    251,
    254,
    257,
    258,
    259,
    260,
    502,
    510,
    541,
    600,
    602,
    603,
    604,
    606,
    704,
    720,
    799,
]);

const clearAction = (line) => {
    line.action = 0;

    for (let i = 0; i < line.args.length; i++)
        line.args[i] = 0;
};

const clearUnusedLineArgs = (line) => {
    let anyValidID = false;

    lineArgsWithSectorIDs.get(line.action).forEach(argNum => {
        if (sectorTags.has(line.args[argNum])) {
            anyValidID = true;
        } else if (line.args[argNum] > 0) {
            line.args[argNum] = 0;
        }
    });

    lineArgsWithLineIDs.get(line.action).forEach(argNum => {
        if (lineTags.has(line.args[argNum])) {
            anyValidID = true;
        } else if (line.args[argNum] > 0) {
            line.args[argNum] = 0;
        }
    });

    lineArgsWithThingIDs.get(line.action).forEach(argNum => {
        if (thingTags.has(line.args[argNum])) {
            anyValidID = true;
        } else if (line.args[argNum] > 0) {
            line.args[argNum] = 0;
        }
    });

    if (!anyValidID)
        clearAction(line);
};

const clearUnusedThingArgs = (thing) => {
    thingArgsWithLineIDs.get(thing.type).forEach(argNum => {
        if (!lineTags.has(thing.args[argNum]) && thing.args[argNum] > 0)
            thing.args[argNum] = 0;
    });
};

let sectors = UDB.Map.getSelectedOrHighlightedSectors();
let lines = UDB.Map.getSelectedOrHighlightedLinedefs();
let things = UDB.Map.getSelectedOrHighlightedThings();
if (sectors.length + lines.length + things.length === 0) {
    sectors = UDB.Map.getSectors();
    lines = UDB.Map.getLinedefs();
    things = UDB.Map.getThings();
}

const sectorTags = new Set();
UDB.Map.getSectors().forEach(sector => {
    sector.getTags()
        .filter(t => t > 0)
        .forEach(t => sectorTags.add(t));
});

const lineTags = new Set();
UDB.Map.getLinedefs().forEach(line => {
    line.getTags()
        .filter(t => t > 0)
        .forEach(t => lineTags.add(t));
});

const thingTags = new Set();
UDB.Map.getThings().forEach(t => {
    if (t.tag > 0)
        thingTags.add(t.tag);
});

const usedSectorTags = new Set();
const usedLineTags = new Set();
const usedThingTags = new Set();

UDB.Map.getLinedefs().forEach(line => {
    let usedArgNums;

    usedArgNums = lineArgsWithSectorIDs.get(line.action);
    usedArgNums?.forEach(n => usedSectorTags.add(line.args[n]));

    lineArgsWithLineIDs.get(line.action)?.forEach(n => usedLineTags.add(line.args[n]));

    usedArgNums = lineArgsWithThingIDs.get(line.action);
    usedArgNums?.forEach(n => usedThingTags.add(line.args[n]));
});

UDB.Map.getThings().forEach(thing => {
    const usedArgNums = thingArgsWithLineIDs.get(thing.action);
    usedArgNums?.forEach(n => usedLineTags.add(thing.args[n]));
});

sectors.forEach(sector => {
    sector.getTags()
        .filter(t => !usedSectorTags.has(t))
        .forEach(t => sector.removeTag(t));
});

lines.forEach(line => {
    line.getTags()
        .filter(t => !usedLineTags.has(t))
        .forEach(t => line.removeTag(t));

    if (clearableLineActions.has(line.action))
        clearUnusedLineArgs(line);
});

things.forEach(thing => {
    if (thing.tag > 0 && !usedThingTags.has(thing.tag))
        thing.tag = 0;

    clearUnusedThingArgs(thing);
});
