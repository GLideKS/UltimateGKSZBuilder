
#region ================== Copyright (c) 2007 Pascal vd Heiden

/*
 * Copyright (c) 2007 Pascal vd Heiden, www.codeimp.com
 * This program is released under GNU General Public License
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 */

#endregion

#region ================== Namespaces

using System;
using System.Collections.Generic;
using System.Globalization;
using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.GZBuilder.Data;

#endregion

namespace CodeImp.DoomBuilder.ZDoom
{
	public sealed class SOCParser : ZDTextParser
	{
		#region ================== Delegates

		public delegate void IncludeDelegate(LuaParser parser, string includefile);
		
		public IncludeDelegate OnInclude;

		#endregion
		
		#region ================== Constants
		
		#endregion
		
		#region ================== Variables

		//mxd. Script type
		internal override ScriptType ScriptType { get { return ScriptType.LUA; } }

		// SRB2 mobjs
		private Dictionary<int, ActorStructure> mobjs;
		private Dictionary<string, MapInfo> mapheaders;

		//mxd. Includes tracking
		private HashSet<string> parsedlumps;

		//mxd. Disposing. Is that really needed?..
		private bool isdisposed;

		//
		public bool NoWarnings = false;

		#endregion

		#region ================== Properties

		/// <summary>
		/// All mobjs that are supported by the current game.
		/// </summary>
		public ICollection<ActorStructure> Mobjs { get { return mobjs.Values; } }
		public Dictionary<string, MapInfo> MapHeaders { get { return mapheaders; } }

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public SOCParser()
		{
			// Syntax
			whitespace = "\n \t\r\u00A0"; //mxd. non-breaking space is also space :)
			specialtokens = "=\n";
			skipregions = false; //mxd

            ClearActors();
		}
		
		// Disposer
		public void Dispose()
		{
			mobjs = null;
			mapheaders = null;
			isdisposed = true;
		}

		#endregion

		#region ================== Parsing

		protected internal override void LogWarning(string message, int linenumber)
		{
			if (NoWarnings)
				return;
			base.LogWarning(message, linenumber);
		}

		// This parses the given SOC stream
		// Returns false on errors
		public override bool Parse(TextResourceData data, bool clearerrors)
		{
			//mxd. Already parsed?
			if(!base.AddTextResource(data))
			{
				if(clearerrors) ClearError();
				return true;
			}

			// Cannot process?
			if(!base.Parse(data, clearerrors)) return false;

			// Continue until at the end of the stream
			while (SkipWhitespace(true, true))
			{
				// Read a token
				string token = ReadToken();

				if (!string.IsNullOrEmpty(token))
				{
					token = token.ToLowerInvariant();

					// SOC object
					if (token.StartsWith("thing") || token.EndsWith("mobj") || token.EndsWith("object"))
					{
						SkipWhitespace(true, true);
						token = ReadToken();

						if (!token.ToUpper().StartsWith("MT_"))
							continue;

						string objname = token;

						// Read actor structure
						ActorStructure mobj = new SOCMobjStructure(this, objname);
						if (this.HasError) return false;

						mobjs[mobj.DoomEdNum] = mobj;
					}
					// Level header
					else if (token.Equals("level"))
					{
						SkipWhitespace(true, true);
						token = ReadToken();

						string mapname = GetMapName(token);

						if (mapname == null)
							continue;

						SOCLevelHeader levelheader = new SOCLevelHeader(this);
						if (this.HasError) return false;

						mapheaders[mapname.ToLowerInvariant()] = levelheader.MapInfo;
					}
				}
			}


			// Return true when no errors occurred
			return (ErrorDescription == null);
		}
		
		#endregion
		
		#region ================== Methods

		public ActorStructure GetMobjByDoomEdNum(int doomednum)
		{
			return mobjs.ContainsKey(doomednum) ? mobjs[doomednum] : null;
		}

        internal void ClearActors()
        {
            // Initialize
			mobjs = new Dictionary<int, ActorStructure>();
			mapheaders = new Dictionary<string, MapInfo>();
			parsedlumps = new HashSet<string>(StringComparer.OrdinalIgnoreCase); //mxd
		}

		private string GetMapName(string number)
		{
			if (int.TryParse(number, NumberStyles.Integer, CultureInfo.InvariantCulture, out int n))
				return ConvertToExtendedMapNum(n);
			else
			{
				if (number.Length != 2 || number[0] < 'A' || number[0] > 'Z' || !((number[1] >= '0' && number[1] <= '9') || (number[1] >= 'A' && number[1] <= 'Z')))
				{
					//ReportError("Invalid level number");
					return null;
				}
				return "MAP" + number;
			}

		}
		private string ConvertToExtendedMapNum(int n)
		{
			if (n <= 0 || n > 1035)
			{
				//ReportError("Invalid level number");
				return null;
			}
			if (n < 10)
				return "MAP0" + n;
			if (n < 100)
				return "MAP" + n.ToString();

			int x = n - 100;
			int p = x / 36;
			int q = x % 36;
			char a = (char)('A' + p);
			char b = (q < 10) ? (char)('0' + q) : (char)('A' + q - 10);
			return "MAP" + String.Concat(a, b);
		}

		#endregion
	}
}
