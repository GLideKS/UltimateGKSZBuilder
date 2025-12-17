/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Change floor height but keep things and offsets heights`;

`#description Change floor height but keep things and offsets heights`;

`#scriptoptions

heightDelta
{
    description = "Height change";
    type = 0;
}
`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

sectors.forEach(sector => {
    sector.floorHeight += UDB.ScriptOptions.heightDelta;

    UDB.Map.getThings().forEach(thing => {
        if (thing.getSector() === sector)
            thing.position.z -= Math.min(UDB.ScriptOptions.heightDelta, thing.position.z);
    });

    sector.getSidedefs().forEach(side => {
        if (side.middleTexture.startsWith('OLDGFZG'))
            side.fields.offsety_mid -= Math.min(UDB.ScriptOptions.heightDelta, side.fields.offsety_mid);
    });
});
