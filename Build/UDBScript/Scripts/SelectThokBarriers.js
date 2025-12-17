/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select thok barriers`;

`#description Select sectors where floor and ceiling heights are the same`;

let sectors = UDB.Map.getSelectedSectors();
if (sectors.length === 0)
    sectors = UDB.Map.getSectors();

UDB.Map.clearAllSelected();

sectors
    .filter(sector => {
        const fp = sector.getFloorPlane();
        const cp = sector.getCeilingPlane();

        const fn = fp.normal;
        const cn = UDB.Vector3D.reversed(cp.normal);

        const fo = fp.offset;
        const co = -cp.offset;

        if (Math.abs(fn.z - 1) < 0.001 && Math.abs(cn.z - 1) < 0.001) {
            return (sector.floorHeight === sector.ceilingHeight);
        } else {
            return (fn.x === cn.x && fn.y === cn.y && fn.z === cn.z && fo === co);
        }
    })
    .forEach(s => s.selected = true);
