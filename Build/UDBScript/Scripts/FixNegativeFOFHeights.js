/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Fix negative FOF heights`;

`#description Fix negative FOF heights`;

UDB.Map.getLinedefs().forEach(line => {
    if (line.action < 100 || line.action >= 300)
        return;

    const sector = line.front.sector;
    if (sector.ceilingHeight >= sector.floorHeight)
        return;

    if (sector.getFloorSlope().getLength() !== 0)
    {
        sector.floorHeight = sector.ceilingHeight - 128;
        UDB.log(`Fixed sector ${sector.index}`);
    }
    else if (sector.getCeilingSlope().getLength() !== 0)
    {
        sector.ceilingHeight = sector.floorHeight + 128;
        UDB.log(`Fixed sector ${sector.index}`);
    }
});
