/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Convert thing height to absolute Z`;


UDB.Map.getSelectedOrHighlightedThings().forEach(thing => {
	const sector = thing.getSector();
	if (thing.flags['absolutez'] == false && sector != null) {
		let plane = sector.getFloorPlane();  
		let z = plane.getZ([thing.position.x, thing.position.y]);
		
		thing.position.z += z;
		thing.flags['absolutez'] = true;
	}
});
