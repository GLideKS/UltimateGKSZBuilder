/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Rescale equation slopes vertically`;

`#scriptoptions

scale
{
	description = "Scaling factor";
	default = 1.0;
	type = 1;
}
`;

const sectors = UDB.Map.getSelectedOrHighlightedSectors();
if (sectors.length === 0)
    UDB.die('No sectors selected');

// const scale = UDB.ScriptOptions.scale;
const scale = 2.0;

sectors.forEach(sector => {
	if (Math.abs(sector.getFloorSlope().getLength() - 1) > 0.001)
		return;

	const vertices = [];
	sector.getSidedefs()
		.map(s => s.line)
		.filter(l => l.front !== l.back)
		.forEach(line => {
			if (!vertices.includes(line.start))
				vertices.push(line.start);
			if (!vertices.includes(line.end))
				vertices.push(line.end);
		});

	if (vertices.length < 3)
		return;

	const oldPlane = new UDB.Plane(sector.getFloorSlope(), sector.floorSlopeOffset);
	const oldPoints = vertices.slice(0, 3).map(v => new UDB.Vector3D(v.position.x, v.position.y, oldPlane.getZ(v.position)));

	const newPoints = oldPoints.map(p => [p.x, p.y, p.z * scale]);
	const newPlane = new UDB.Plane(newPoints[0], newPoints[1], newPoints[2], true);

	sector.setFloorSlope(newPlane.normal);
	sector.floorSlopeOffset = newPlane.offset;
});
