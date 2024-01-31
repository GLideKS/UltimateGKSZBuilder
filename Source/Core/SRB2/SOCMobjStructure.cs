using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodeImp.DoomBuilder.ZDoom
{

    public sealed class SOCMobjStructure : ActorStructure
	{
        #region ================== SOC Mobj Structure parsing

        internal SOCMobjStructure(ZDTextParser zdparser, string objname)
        {
			classname = string.Empty;

            SOCParser parser = (SOCParser)zdparser;
			General.WriteLogLine(objname);

			if (string.IsNullOrEmpty(objname))
            {
                parser.ReportError("SOC object structure has no object name or map thing number");
                return;
            }

			// Now parse the contents of actor structure

			while (parser.SkipWhitespace(false, true))
			{
				string token = parser.ReadToken();
				token = token.ToLowerInvariant();

				if (token == "\n")
				{
					parser.SkipWhitespace(false, true);
					token = parser.ReadToken();
				}

				// Property begins with $? Then the whole line is a single value
				if (token.Contains("$"))
				{
					token = token.ToLowerInvariant().Trim(new char[] { '#' });

					switch (token)
					{
						case "$wallsprite":
						case "$flatsprite":
						case "$spawnceiling":
							flags[token.Substring(1)] = true;
							parser.ReadLine();
							break;
						case "$name":
							token = "$title";
							goto default;
						default:
							props[token] = new List<string> { (parser.SkipWhitespace(false, true) ? parser.ReadLine() : "") };
							break;
					}
				}
				else
				{
					string tokenname = token;
					parser.SkipWhitespace(false, true);
					token = parser.ReadToken();

					General.WriteLogLine(tokenname);
					General.WriteLogLine(token);

					// SOC definitions are terminated by an empty line. Blegh.
					if (tokenname == "\n")
					{
						General.WriteLogLine("object definition done");
						break;
					}

					if (token != "=")
					{
						parser.ReportError("Invalid SOC object parameter definition, missing =");
						return;
					}

					parser.SkipWhitespace(true, true);
					token = parser.ReadToken();
					tokenname = tokenname.ToLowerInvariant();

					List<string> values = new List<string>() { token.TrimEnd(new char[] { ',' }) };

					//mxd. Translate scale to xscale and yscale
					switch (tokenname)
					{
						case "scale":
							props["xscale"] = values;
							props["yscale"] = values;
							break;
						case "doomednum":
						case "mapthingnum":
							doomednum = int.Parse(values[0]);
							goto default;
						case "height":
						case "radius":
							props[tokenname] = new List<string>() { ReadFracunit(values[0]).ToString() };
							break;
						default:
							props[tokenname] = values;
							break;
					}
				}
			}

			// parsing done, process thing arguments
			ParseCustomArguments();
		}

		private static string ReadFracunit(string input)
		{
			if (input.Contains("FRACUNIT") || input.Contains("FRACBITS") || input.Contains("FU"))
				return new string(input.Where(c => char.IsDigit(c)).ToArray());
			else
				return (int.Parse(input) >> 16).ToString();
		}

		#endregion
	}
}
