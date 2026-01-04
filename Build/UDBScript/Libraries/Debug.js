/// <reference path="../udbscript.d.ts" />

const useNewLines = false;

const iteratePrototypeNames = [
	'Object',
	'Array',
];

serialiseValue = (value, prefix, cycles) => {
	if (value === null) {
		return 'null';
	} else if (typeof value === 'string') {
		return `'${value}'`;
	} else if (typeof value === 'object' && iteratePrototypeNames.includes(value.constructor.name)) {
		if (cycles.has(value)) {
			return `<${value.toString()}>`;
		} else {
			cycles.add(value);
		}

		const newPrefix = useNewLines ? prefix + '    ' : '';
		const parts = [];

		parts.push('{');

		for (const k in value) {
			const vs = serialiseValue(value[k], newPrefix, cycles);
			parts.push(`${newPrefix}${k}: ${vs},`);
		}

		parts.push(prefix + '}');

		return parts.join(useNewLines ? '\n' : ' ');
	} else {
		return value.toString();
	}
};

dump = (label, value) => {
    if (value === undefined)
        [value, label] = [label, undefined];

    const s = serialiseValue(value, '', new Set());

	UDB.log(label ? `${label} = ${s}` : s);
};

profStart = () => {
	return Date.now();
};

profEnd = (startTime, label) => {
	const time = Date.now() - startTime;
	UDB.log(`${label ?? 'time'}: ${time}ms`);
};
