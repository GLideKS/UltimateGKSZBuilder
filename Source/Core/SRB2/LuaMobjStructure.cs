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

    public sealed class LuaMobjStructure : ActorStructure
	{
        #region ================== DECORATE Actor Structure parsing

        internal LuaMobjStructure(ZDTextParser zdparser, string objname, int editnum)
        {
			classname = string.Empty;

            LuaParser parser = (LuaParser)zdparser;
            bool done = false; //mxd
			General.WriteLogLine(objname);

			if (string.IsNullOrEmpty(objname) && editnum == 0)
            {
                parser.ReportError("Lua object structure has no object name or map thing number");
                return;
			}
			else
				props["$title"] = new List<string> { objname };

			if (editnum > 0)
				doomednum = editnum;

			// Now parse the contents of actor structure

			while (parser.SkipWhitespace(true))
			{
				string token = parser.ReadToken();
				token = token.ToLowerInvariant();

				switch (token)
				{
					case "}":
					case "$}":
						// Actor scope ends here, break out of this parse loop
						done = true;
						break;

					// Property
					default:
						//General.WriteLogLine(token);
						// Property begins with $? Then the whole line is a single value
						if (token.Contains("$"))
						{
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
									props[token] = new List<string> { parser.SkipWhitespace(false) ? parser.ReadLine() : "" };
									break;
							}
						}
						else
						{
							string tokenname = token;
							parser.SkipWhitespace(true);
							token = parser.ReadToken();

							if (token != "=")
							{
								parser.ReportError("Invalid Lua object parameter definition, missing =");
								return;
							}

							parser.SkipWhitespace(true);
							token = parser.ReadToken();

							if (!token.EndsWith(","))
							{
								done = true;
							}

							List<string> values = new List<string>() { token.TrimEnd(new char[] { ',' }) };

							//mxd. Translate scale to xscale and yscale
							switch (tokenname)
							{
								case "scale":
									props["xscale"] = values;
									props["yscale"] = values;
									break;
								case "doomednum":
									doomednum = (editnum > 0) ? editnum : int.Parse(values[0]);
									goto default;
								case "height":
								case "radius":
									props[tokenname] = new List<string>() { ReadFracunit(values[0], parser) };
									break;
								default:
									props[tokenname] = values;
									break;
							}
						}
						break;
				}

				if (done) break; //mxd
			}

			// parsing done, process thing arguments
			ParseCustomArguments();
		}

		#endregion
	}
}
