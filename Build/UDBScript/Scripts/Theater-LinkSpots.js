/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Theater - Link spots together`;

`#description Link selected spots together into a chain.`;

const getThingLinks = thing => {
    const arg0 = thing.fields['stringarg0'] ?? '';
    if (arg0 === '')
        return [];
    const links = arg0.split(' ').map(t => parseInt(t));
    if (links.includes(NaN))
        UDB.die(`Malformed string argument 1 for thing ${thing.index} (${arg0})`);
    return links;
}

const setThingLinks = (thing, links) => {
    thing.fields['stringarg0'] = links.join(' ');
}

let things = UDB.Map.getSelectedThings();
if (things.length < 2)
    UDB.die('You must select at least two things');

for (let i = 0; i < things.length - 1; i++) {
    const thing = things[i];
    const nextThing = things[i + 1];

    const links = getThingLinks(thing);
    const nextLinks = getThingLinks(nextThing);

    if (!links.includes(nextThing.tag))
        links.push(nextThing.tag);
    if (!nextLinks.includes(thing.tag))
        nextLinks.push(thing.tag);

    setThingLinks(thing, links);
    setThingLinks(nextThing, nextLinks);
}
