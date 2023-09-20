
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
using System.IO;
using CodeImp.DoomBuilder.Config;
using CodeImp.DoomBuilder.Data;
using CodeImp.DoomBuilder.Types;

#endregion

namespace CodeImp.DoomBuilder.ZDoom
{
	public sealed class LuaParser : ZDTextParser
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

		#endregion

		#region ================== Constructor / Disposer

		// Constructor
		public LuaParser()
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

		// This parses the given Lua stream
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
			while (SkipWhitespace(true))
			{
				// Read a token
				string token = ReadToken();

				if (!string.IsNullOrEmpty(token))
				{
					string objname = null;
					int editnum = 0;

					if (token.Contains("$EditInfo"))
					{
						SkipWhitespace(true);
						token = ReadToken();

						bool valid = int.TryParse(token, out editnum);
						if (!valid || editnum <= 0)
						{
							continue;
						}
					}
					else
					{
						if (!token.StartsWith("mobjinfo[") || !token.EndsWith("]")) continue;
						objname = token.Substring(9).TrimEnd(new char[] { ']' });

						SkipWhitespace(true);
						token = ReadToken();

						if (token != "=")
						{
							continue;
						}
					}

					SkipWhitespace(true);
					token = ReadToken();

					if (token != "{")
					{
						ReportError("Invalid object definition, missing {");
						return false;
					}

					// Read actor structure
					ActorStructure mobj = new LuaMobjStructure(this, objname, editnum);
					if (this.HasError) return false;

					mobjs[mobj.DoomEdNum] = mobj;
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
			parsedlumps = new HashSet<string>(StringComparer.OrdinalIgnoreCase); //mxd
		}

		#endregion
	}
}
