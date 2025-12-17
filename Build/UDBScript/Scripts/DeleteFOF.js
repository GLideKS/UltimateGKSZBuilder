/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Delete FOF`;

`#description Delete the selected FOFs`;

if (!UDB.Map.srb2_visualSelection)
    UDB.die('You can only use this action in visual mode.');

const tagToClearableLines = new Map();

UDB.Map.srb2_visualSelection.forEach((element) => {
    if (!element.type.startsWith('3dfloor'))
        return;

    const fofLine = element.controlLinedef;
    const tag = fofLine.args[0];

    element.sector.removeTag(tag);

    if (tagToClearableLines.has(tag))
        tagToClearableLines.get(tag).push(fofLine);
    else
        tagToClearableLines.set(tag, [fofLine]);
});

if (tagToClearableLines.size === 0)
    UDB.die('No FOFs selected.');

UDB.Map.getSectors().forEach(sector => {
    sector.getTags().forEach(t => tagToClearableLines.delete(t));
});

tagToClearableLines.forEach(fofLines => fofLines.forEach(fofLine => {
    fofLine.action = 0;
    for (let i = 0; i < fofLine.args.length; i++)
        fofLine.args[i] = 0;
    fofLine.getTags().forEach(t => fofLine.removeTag(t));
    fofLine.clearFlags();

    if (false) {
        const fofSector = fofLine.front.sector;

        fofSector.getTags().forEach(t => fofSector.removeTag(t));
        fofSector.clearFlags();
    }
}));

// const fofLines = UDB.Map.getSelectedOrHighlightedLinedefs();
// if (fofLines.length === 0)
//     UDB.die('No FOFs selected. Select the side of the FOFs to be deleted.');

// const selectedSectors = UDB.Map.getSelectedOrHighlightedSectors();
// if (selectedSectors.length === 0)
//     UDB.die('No sectors selected.');

// fofLines.forEach((fofLine) => {
//     if (!(SRB2ControlSector.isFofLine(fofLine) && fofLine.front))
//         return;

//     const tag = fofLine.args[0];
//     const fofSector = fofLine.front.sector;
//     const sectors = SRB2ControlSector.findTargetSectors(tag, selectedSectors);

//     sectors.forEach(s => s.removeTag(tag));

//     fofLine.action = 0;
//     for (let i = 0; i < fofLine.args.length; i++)
//         fofLine.args[i] = 0;
//     fofLine.getTags().forEach(t => fofLine.removeTag(t));
//     fofLine.clearFlags();

//     if (false) {
//         fofSector.getTags().forEach(t => fofSector.removeTag(t));
//         fofSector.clearFlags();
//     }
// });
