/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Add FOF`;

`#description Add a new FOF inside the selected sectors`;

`#scriptoptions

interactive
{
    description = "Interactive (opens a window)";
    type = 3;
    default = false;
}

topTexture
{
    description = "Top texture";
    type = 6;
    default = "GFZROCK";
}

sideTexture
{
    description = "Side texture";
    type = 6;
    default = "GFZROCK";
}

bottomTexture
{
    description = "Bottom texture";
    type = 6;
    default = "GFZROCK";
}
`;

const getRaisedPlane = (plane, delta) =>
    new UDB.Plane(plane.normal, plane.offset - plane.normal.z * delta);

const getRaisedSectorSlope = (slope, slopeOffset, delta) =>
    slopeOffset - slope.z * delta;

const queryOptions = () => {
    const options = new UDB.QueryOptions();

    options.addOption('topTexture', 'Top texture', 6, UDB.ScriptOptions.topTexture);
    options.addOption('sideTexture', 'Side texture', 6, UDB.ScriptOptions.sideTexture);
    options.addOption('bottomTexture', 'Bottom texture', 6, UDB.ScriptOptions.bottomTexture);

    if (!options.query())
        UDB.exit();

    UDB.ScriptOptions.topTexture = options.options.topTexture;
    UDB.ScriptOptions.sideTexture = options.options.sideTexture;
    UDB.ScriptOptions.bottomTexture = options.options.bottomTexture;
};

const setReasonableDefaultHeights = (sector, fofSector) => {
    const distanceFromSurface = 64;
    const height = 64;

    fofSector.floorHeight = sector.floorHeight + distanceFromSurface;
    fofSector.ceilingHeight = fofSector.floorHeight + height;

    const bottomPlane = getRaisedPlane(sector.getFloorPlane(), distanceFromSurface);
    if (Math.abs(bottomPlane.normal.z - 1) > 0.001) {
        fofSector.setFloorSlope(bottomPlane.normal);
        fofSector.floorSlopeOffset = bottomPlane.offset;
    } else {
        fofSector.setFloorSlope([0, 0, 0]);
        fofSector.floorSlopeOffset = NaN;
    }

    const topPlane = getRaisedPlane(fofSector.getFloorPlane(), height);
    if (Math.abs(topPlane.normal.z - 1) > 0.001) {
        fofSector.setCeilingSlope(UDB.Vector3D.reversed(topPlane.normal));
        fofSector.ceilingSlopeOffset = -topPlane.offset;
    } else {
        fofSector.setCeilingSlope([0, 0, 0]);
        fofSector.ceilingSlopeOffset = NaN;
    }
}

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

const controlSectors = SRB2ControlSector.sortControlSectors(SRB2ControlSector.findUnusedControlSectors());
if (controlSectors.length < sectors.length)
    UDB.die('Not enough control sectors available');

if (UDB.ScriptOptions.interactive)
    queryOptions();

UDB.Map.clearAllSelected();

sectors.forEach((sector, i) => {
    if (SRB2ControlSector.isFofSector(sector))
        return;

    const fofSector = controlSectors[i];
    const fofLines = fofSector.getSidedefs().map(s => s.line);
    const fofLine = SRB2ControlSector.findBestControlLine(fofLines);

    const tag = UDB.Map.getNewTag();

    sector.addTag(tag);

    fofLine.action = 100;
    fofLine.args[0] = tag;
    fofLine.args[1] = 255;

    fofSector.ceilingTexture = sector.floorTexture;
    fofLine.front.middleTexture = sector.floorTexture;
    fofSector.floorTexture = sector.floorTexture;
    // fofSector.ceilingTexture = UDB.ScriptOptions.topTexture;
    // fofLine.front.middleTexture = UDB.ScriptOptions.sideTexture;
    // fofSector.floorTexture = UDB.ScriptOptions.bottomTexture;

    setReasonableDefaultHeights(sector, fofSector);

    fofSector.brightness = sector.brightness

    fofSector.floorSelected = true;
    fofLine.front.middleSelected = true;
    fofSector.ceilingSelected = true;
});
