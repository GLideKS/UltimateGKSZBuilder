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

        internal LuaMobjStructure(ZDTextParser zdparser, string objname)
        {
			classname = string.Empty;

            LuaParser parser = (LuaParser)zdparser;
            bool done = false; //mxd
			General.WriteLogLine(objname);

			if (string.IsNullOrEmpty(objname))
            {
                parser.ReportError("Expected actor class name");
                return;
            }

			// Now parse the contents of actor structure

			while (parser.SkipWhitespace(true))
			{
				string token = parser.ReadToken();
				token = token.ToLowerInvariant();

				switch (token)
				{
					case "}":
						// Actor scope ends here, break out of this parse loop
						done = true;
						break;

					// Property
					default:
						General.WriteLogLine(token);
						// Property begins with $? Then the whole line is a single value
						if (token.Contains("$"))
						{
							bool isflag = false;
							bool isname = false;

							switch (token)
							{
								case "$name":
									token = "$title";
									isname = true;
									break;
								case "$wallsprite":
								case "$flatsprite":
								case "$spawnceiling":
									isflag = true;
									break;
							}
							// This is for editor-only properties such as $sprite and $category
							string t = token;
							if (isflag)
							{
								parser.SkipWhitespace(false);
								string val = parser.ReadLine();
								flags[t.Substring(1)] = (val == "true" || val == "1") ? true : false;
							}
							else
								props[token] = new List<string> { (parser.SkipWhitespace(false) ? parser.ReadLine() : "") };

							if (isname)
							{
								General.WriteLogLine("name = " + props["$title"][0]);
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
									doomednum = int.Parse(values[0]);
									General.WriteLogLine("parsed doomednum: " + DoomEdNum);
									goto default;
								case "height":
								case "radius":
									props[tokenname] = new List<string>() { GetNumbers(values[0]).ToString() };
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

		private static string GetNumbers(string input)
		{
			return new string(input.Where(c => char.IsDigit(c)).ToArray());
		}

		#endregion
	}
}
