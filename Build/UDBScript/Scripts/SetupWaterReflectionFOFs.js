/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Setup water reflection FOFs`;

`#description Setup the FOFs belonging to the selected sectors to be vertically mirrored`;

const getSectorVertices = sector => {
    const vertices = [];

    sector.getSidedefs().forEach(side => {
        vertices.push(side.line.start);
        vertices.push(side.line.end);
    });

    return vertices;
}

const findSectorFloorLowestZ = sector => {
    const plane = new UDB.Plane(sector.getFloorSlope(), sector.floorSlopeOffset);

    return Math.min(...getSectorVertices(sector).map(v =>
        plane.getZ([v.position.x, v.position.y])
    ));
};

UDB.Map.getSelectedOrHighlightedSectors().forEach(sector => {
    const fofLine = UDB.Map.getLinedefs().find(l => l.args[0] === sector.tag);
    const fofSector = fofLine.front.sector;
    const slope = sector.getFloorSlope();

    fofSector.setCeilingSlope([-slope.x, -slope.y, -slope.z]);
    fofSector.ceilingSlopeOffset = -sector.floorSlopeOffset;

    fofSector.setFloorSlope([-slope.x, -slope.y, slope.z]);
    fofSector.floorSlopeOffset = -sector.floorSlopeOffset;

    fofSector.floorTexture = sector.floorTexture;
    fofSector.ceilingTexture = sector.floorTexture;
    fofLine.front.middleTexture = sector.floorTexture;


    // const slope = fofSector.getCeilingSlope();

    // fofSector.setCeilingSlope([-slope.x, -slope.y, -slope.z]);
    // fofSector.ceilingSlopeOffset = -fofSector.floorSlopeOffset;

    // fofSector.setFloorSlope([slope.x, slope.y, -slope.z]);
    // fofSector.floorSlopeOffset = fofSector.ceilingSlopeOffset;
});
