/// <reference path="../udbscript.d.ts" />

class SRB2ControlSector {
    static fofActions = new Set([100, 120, 150, 160, 170, 190, 200, 202, 220, 223, 250, 251, 254, 257, 258, 259]);

    static findUnusedControlSectors(multiplePerSector = false) {
        return UDB.Map.getSectors().filter(sector => {
            if (sector.fields.udbscript_controlsector === undefined)
                return false;

            if (multiplePerSector)
                return sector.getSidedefs().some(s => s.line.action === 0);
            else
                return !sector.getSidedefs().some(s => s.line.action !== 0);
        });
    }

    static findUnusedControlLines(multiplePerSector = false) {
        let unusedLines = [];

        const sectors = this.sortControlSectors(this.findUnusedControlSectors(multiplePerSector));

        for (const sector of sectors) {
            if (multiplePerSector) {
                for (const side of sector.getSidedefs()) {
                    const line = side.line;
                    if (line.action === 0)
                        unusedLines.push(line);
                }
            } else {
                const lines = this.sortLines(sector.getSidedefs().map(s => s.line));
                unusedLines.push(lines.find(l => l.action === 0));
            }
        }

        return unusedLines;
    }

    static sortControlSectors(sectors) {
        const sectorProxies = sectors.map(sector => {
            const lines = sector.getSidedefs().map(s => s.line)
            const center = this.findBestControlLine(lines).getCenterPoint();

            return {
                sector,
                x: center.x,
                y: center.y,
            }
        });

        sectorProxies.sort((a, b) => {
            if (a.y !== b.y)
                return b.y - a.y;
            else
                return a.x - b.x;
        })

        return sectorProxies.map(s => s.sector);
    }

    static sortControlLines(lines) {
        const lineProxies = lines.map(line => {
            const center = line.getCenterPoint();
            return {
                line,
                x: center.x,
                y: center.y,
            }
        });

        lineProxies.sort((a, b) => {
            if (a.y !== b.y)
                return b.y - a.y;
            else
                return a.x - b.x;
        })

        return lineProxies.map(l => l.line);
    }

    static findBestControlLine(lines) {
        let bestLine = lines[0];
        let { x: bestX, y: bestY } = bestLine.getCenterPoint();

        for (let i = 1; i < lines.length; i++) {
            const { x, y } = lines[i].getCenterPoint();

            let better = false;
            if (y !== bestY)
                better = (y > bestY);
            else
                better = (x < bestX);

            if (better) {
                bestLine = lines[i];
                bestX = x;
                bestY = y;
            }
        }

        return bestLine;
    }

    static findTargetSectors(tag, sectors) {
        return (sectors ?? UDB.Map.getSectors()).filter(s => s.getTags().includes(tag));
    }

    static isControlLine(line) {
        return line.action !== 0;
    }

    static isControlSector(sector) {
        return sector.getSidedefs().some(s => this.isControlLine(s.line));
    }

    static isFofLine(line) {
        return SRB2ControlSector.fofActions.has(line.action);
    }

    static isFofSector(sector) {
        return sector.getSidedefs().some(s => this.isFofLine(s.line));
    }
}
