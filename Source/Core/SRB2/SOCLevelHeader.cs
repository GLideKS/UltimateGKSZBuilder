using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.GZBuilder.Data;
using CodeImp.DoomBuilder.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodeImp.DoomBuilder.ZDoom
{

    public sealed class SOCLevelHeader
	{

		#region ================== Variables

		private MapInfo mapinfo;

		#endregion

		#region ================== Properties

		public MapInfo MapInfo { get { return mapinfo; } }

		#endregion

		#region ================== SOC level header parsing

		internal SOCLevelHeader(ZDTextParser zdparser)
		{
			mapinfo = new MapInfo();
			string levelname = "Unnamed map";
			int actnum = 0;
			bool nozone = false;

			SOCParser parser = (SOCParser)zdparser;

			// Parse contents of level header
			string line = parser.ReadLine();
			while (line != null)
			{
				line = parser.ReadLine();
				if (string.IsNullOrEmpty(line) || line.StartsWith("\n")) break;
				if (line.StartsWith("#")) continue;

				line = line.Split(new char[] { '#' })[0];

				string[] tokens = line.Split(new char[] { '=' });
				if (tokens.Length != 2)
				{
					parser.ReportError("Invalid line");
					return;
				}

				tokens[0] = tokens[0].Trim().ToLowerInvariant();
				tokens[1] = tokens[1].Trim();

				switch (tokens[0])
				{
					case "levelname":
						levelname = tokens[1];
						break;
					case "act":
						if (!int.TryParse(tokens[1], out actnum) || actnum > 99)
						{
							parser.LogWarning("Invalid act number (" + tokens[1] + ") found; must be a number ranging from 0 to 99");
							actnum = 0;
						}
						break;
					case "nozone":
						string value = tokens[1].ToLowerInvariant();
						nozone = (value.StartsWith("t") || value.StartsWith("y"));
						break;
					case "skynum":
						mapinfo.Sky1 = "SKY" + tokens[1];
						break;
					default:
						break;
				}
				
			}

			mapinfo.Title = levelname + (nozone ? "" : " Zone") + (actnum > 0 ? ", Act " + actnum : "");
		}

		#endregion
	}
}
