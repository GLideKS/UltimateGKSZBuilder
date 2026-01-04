/// <reference path="../../udbscript.d.ts" />

`#version 4`;

`#name Apply textures to selected surfaces`;

`#description Applies GFZFLR02 to the selected floors/ceilings, and GFZROCK to the selected upper/middle/lower sidedefs. Mostly useful in visual mode`;

// Get all selected or highlighted sectors and sidedefs
let elements = UDB.Map.getSelectedOrHighlightedSectors().concat(UDB.Map.getSidedefsFromSelectedOrHighlightedLinedefs());

// Since the array might contain both selected sectors and highlighted sidedefs (or vice versa)
// we have to filter the array, so that we really only work on the correct map elements, i.e.
// either the single highlighted one, or all selected ones
elements.filter(e => {
    if( elements.length == 1 ||
        (e instanceof UDB.Sector && (e.floorSelected || e.ceilingSelected)) ||
        (e instanceof UDB.Sidedef && (e.upperSelected || e.middleSelected || e.lowerSelected))
    ) return true;
    return false;
}).forEach(e => {
    // Check for each sector and sidedef which part is selected/highlighted and
    // apply the textures accordingly
    if(e instanceof UDB.Sector)
    {
        if(e.floorSelected || e.floorHighlighted)
            e.floorTexture = 'GFZFLR02';

        if(e.ceilingSelected || e.ceilingHighlighted)
            e.ceilingTexture = 'GFZFLR02';
    }
    else if(e instanceof UDB.Sidedef)
    {
        if(e.lowerSelected || e.lowerHighlighted)
            e.lowerTexture = 'GFZROCK';

        if(e.middleSelected || e.middleHighlighted)
            e.middleTexture = 'GFZROCK';

        if(e.upperSelected || e.upperHighlighted)
            e.upperTexture = 'GFZROCK';
    }
});