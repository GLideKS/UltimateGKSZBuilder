/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select FOF control linedefs`;

`#description Select the control linedefs of the selected sectors or FOFs`;

const selectLine = (line) => {
    if (SRB2ControlSector.isFofLine(line) && line.front) {
        line.selected = true;
        line.front.middleSelected = true;
    }
};

const elements = UDB.Map.srb2_visualSelection;
if (!elements)
    UDB.die('Can only be used in visual mode.');

UDB.Map.clearAllSelected();

elements.forEach(element => {
    if (['floor', 'ceiling'].includes(element.type)) {
        element.sector.getTags().forEach(tag => {
            const controlLines = UDB.Map.getLinedefs().filter(line =>
                line.args[0] === tag && SRB2ControlSector.isFofLine(line));

            controlLines.forEach(selectLine);
        })
    } else if (element.type.startsWith('3dfloor')) {
        selectLine(element.controlLinedef);
    }
});
