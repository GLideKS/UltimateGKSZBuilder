/// <reference path="../udbscript.d.ts" />

`#version 5`;

`#name Select extra vertices`;

`#description Given a selection of vertices, this only keeps vertices that are not essential to sector geometry selected.`;

UDB.Map.getSelectedOrHighlightedVertices().forEach(vertex => {
	let lines = vertex.getLinedefs();
	if (lines.length == 2)
	{
		let l1 = lines[0].angle%180;
		let l2 = lines[1].angle%180;
		if (l1 != l2)
		{
			vertex.selected = false;
		}
	}
	else
	{
		vertex.selected = false;
	}
});

