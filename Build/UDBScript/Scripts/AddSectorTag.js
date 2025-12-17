/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Add sector tag`;

`#description Add tag to selected sectors`;

`#scriptoptions

tag
{
    description = "Tag to add";
    type = 13;
}
`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

sectors.forEach(sector => {
    sector.addTag(UDB.ScriptOptions.tag);
});
