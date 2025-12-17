/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select FOF control sectors`;

`#description Select the control sectors of the selected sectors or FOFs`;

const selectLineSector = (line) => {
    if (!SRB2ControlSector.isFofLine(line))
        return;

    const sector = line.front?.sector;
    if (!sector)
        return;

    sector.floorSelected = true;
    sector.selected = true;
    sector.ceilingSelected = true;
};

let elements = UDB.Map.srb2_visualSelection;

if (!elements) {
    elements = [];

    UDB.Map.getSelectedOrHighlightedSectors().forEach(sector => {
        sector.getTags().forEach(tag => {
            elements.push({ type: 'floor', sector });
        });
    });
}

if (elements.length === 0)
    UDB.die('No FOFs or sectors selected.');

UDB.Map.clearAllSelected();

// elements.forEach(element => {
//     if (element instanceof UDB.Sector) {
//         element.getTags().forEach(tag => {
//             const controlLines = UDB.Map.getLinedefs().filter(line =>
//                 line.args[0] === tag && SRB2ControlSector.isFofLine(line));

//             controlLines.forEach(selectLineSector);
//         })
//     } else {
//         selectLineSector(element);
//     }
// });

elements.forEach(element => {
    if (['floor', 'ceiling'].includes(element.type)) {
        element.sector.getTags().forEach(tag => {
            const controlLines = UDB.Map.getLinedefs().filter(line =>
                line.args[0] === tag && SRB2ControlSector.isFofLine(line));

            controlLines.forEach(selectLineSector);
        })
    } else if (element.type.startsWith('3dfloor')) {
        selectLineSector(element.controlLinedef);
    }
});

// /// <reference path="../udbscript.d.ts" />

// `#version 5`;

// `#name Select FOF control sectors`;

// `#description Select the control sectors of the selected sectors or FOF sides`;

// const selectLineSector = (line) => {
//     if (!SRB2ControlSector.isFofLine(line))
//         return;

//     const sector = line.front?.sector;
//     if (!sector)
//         return;

//     sector.floorSelected = true;
//     sector.selected = true;
//     sector.ceilingSelected = true;
// };

// const elements = [
//     ...UDB.Map.getSelectedOrHighlightedSectors(),
//     ...UDB.Map.getSelectedOrHighlightedLinedefs(),
// ];

// if (elements.length === 0)
//     UDB.die('No linedefs or sectors selected.');

// UDB.Map.clearAllSelected();

// elements.forEach(element => {
//     if (element instanceof UDB.Sector) {
//         element.getTags().forEach(tag => {
//             const controlLines = UDB.Map.getLinedefs().filter(line =>
//                 line.args[0] === tag && SRB2ControlSector.isFofLine(line));

//             controlLines.forEach(selectLineSector);
//         })
//     } else {
//         selectLineSector(element);
//     }
// });
