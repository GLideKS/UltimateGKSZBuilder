/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Test`;

`#description Test`;

const sel = UDB.Map.srb2_visualSelection[0];
for (const k in sel) {
    UDB.log(`${k} ${sel[k]}`);
}
