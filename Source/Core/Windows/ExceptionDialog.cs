#region ================== Namespaces

using System;
using System.IO;
using System.Management;
using System.Windows.Forms;
using System.Threading;

#endregion

namespace CodeImp.DoomBuilder.Windows
{
	public partial class ExceptionDialog : Form
	{
		private const string CRASH_DUMP_FILE = "UZBCrash.txt";

		private readonly bool isterminating;
		private readonly string logpath;
		
		public ExceptionDialog(UnhandledExceptionEventArgs e) 
		{
			InitializeComponent();

			logpath = Path.Combine(General.SettingsPath, CRASH_DUMP_FILE);
			Exception ex = (Exception)e.ExceptionObject;
			errorDescription.Text = "Error in " + ex.Source + ":";
			string sysinfo = GetSystemInfo();
			using(StreamWriter sw = File.CreateText(logpath)) 
			{
				sw.Write(sysinfo + GetExceptionDescription(ex));
			}

			errorMessage.Text = ex.Message + Environment.NewLine + ex.StackTrace;
			isterminating = e.IsTerminating;  // Recoverable?
		}

		public ExceptionDialog(ThreadExceptionEventArgs e) 
		{
			InitializeComponent();

			logpath = Path.Combine(General.SettingsPath, CRASH_DUMP_FILE);
			errorDescription.Text = "Error in " + e.Exception.Source + ":";
			string sysinfo = GetSystemInfo();
			using(StreamWriter sw = File.CreateText(logpath)) 
			{
				sw.Write(sysinfo + GetExceptionDescription(e.Exception));
			}

			errorMessage.Text = sysinfo + "********EXCEPTION DETAILS********" + Environment.NewLine 
				+ e.Exception.Message + Environment.NewLine + e.Exception.StackTrace;
		}

		public void Setup() 
		{
			string[] titles =
			{
				"Ultimate Zone Builder was killed by Eggman's nefarious TV magic.",
				"Ultimate Zone Builder was killed by an environmental hazard.",
				"Ultimate Zone Builder drowned.",
				"Ultimate Zone Builder was crushed.",
				"Ultimate Zone Builder fell into a bottomless pit.",
				"Ultimate Zone Builder asphyxiated in space.",
				"Ultimate Zone Builder died.",
				"Ultimate Zone Builder's playtime with heavy objects killed Ultimate Zone Builder.",
				"Resynching...",
				"You have been banned from the server.",
				"SIGSEGV - segment violation",
				"[Eggman laughing]",
				"[Armageddon pow]",
				"[Dying]",
				"I'm outta here...",
				"GAME OVER",
				"SONIC MADE A BAD FUTURE IN Ultimate Zone Builder",
				"Sonic arrived just in time to see what little of the 'ruins' were left.",
				"The natural beauty of the zone had been obliterated.",
				"I'm putting my foot down.",
				"All of this is over. You will be left with ashes.",
				"some doofus gave us an empty string?",
				"unfortunate player falls into spike?!",
				"Ack! Metal Sonic shouldn't die! Cut the tape, end recording!",
				"ALL YOUR RINGS ARE BELONG TO US!",
				"Hohohoho!! *B^D",
				"So that's it. I was so busy playing SRB2 I never noticed... but... everything's gone...",
				"Tails! You made the engines quit!",
				"Oh no, we dead? D:",
				@"oh no! back to reality!\r\n",
				"They're dead, Jim.",
				"We're dead now. De-solidify.",
				"Yousa dead now, Okieday?"
			};

			this.Text = titles[new Random().Next(0, titles.Length - 1)];
			bContinue.Enabled = !isterminating;
		}

		private static string GetSystemInfo()
		{
			string result = "***********SYSTEM INFO***********" + Environment.NewLine;
			
			// Get OS name
			ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
			foreach(ManagementBaseObject mo in searcher.Get())
			{
				result += "OS: " + mo["Caption"] + Environment.NewLine;
				break;
			}

			// Get GPU name
			searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController");
			foreach(ManagementBaseObject mo in searcher.Get())
			{
				PropertyData bpp = mo.Properties["CurrentBitsPerPixel"];
				PropertyData description = mo.Properties["Description"];
				if(bpp != null && description != null && bpp.Value != null)
				{
					result += "GPU: " + description.Value + Environment.NewLine;
					break;
				}
			}

            // Get UZB version
            result += "UZB: v" + General.ThisAssembly.GetName().Version + Environment.NewLine;
            result += "Platform: " + (Environment.Is64BitProcess ? "x64" : "x86") + Environment.NewLine + Environment.NewLine;

			return result;
		}

		private static string GetExceptionDescription(Exception ex) 
		{
			// Add to error logger
			General.WriteLogLine("***********************************************************");
			General.ErrorLogger.Add(ErrorType.Error, ex.Source + ": " + ex.Message);
			General.WriteLogLine("***********************************************************");

			string message = "********EXCEPTION DETAILS********"
							 + Environment.NewLine + ex.Source + ": " + ex.Message + Environment.NewLine + ex.StackTrace;

			if(File.Exists(General.LogFile)) 
			{
				try 
				{
					string[] lines = File.ReadAllLines(General.LogFile);
					message += Environment.NewLine + Environment.NewLine + "***********ACTIONS LOG***********";
					for(int i = lines.Length - 1; i > -1; i--) 
						message += Environment.NewLine + lines[i];
				} catch(Exception) { }
			}

			return message;
		}

		private void reportlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
		{
			if(!File.Exists(logpath)) return;
			try { System.Diagnostics.Process.Start("explorer.exe", @"/select, " + logpath); }
			catch { MessageBox.Show("Unable to show the error report location..."); }
			reportlink.LinkVisited = true;
		}

		private void newissue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) 
		{
			try { System.Diagnostics.Process.Start("https://github.com/GLideKS/UltimateGKSZBuilder/issues"); } 
			catch { MessageBox.Show("Unable to open URL..."); }
			newissue.LinkVisited = true;
		}

		private void bContinue_Click(object sender, EventArgs e) 
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void bQuit_Click(object sender, EventArgs e)
		{
			if(General.Map != null) General.Map.SaveMapBackup();
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void bToClipboard_Click(object sender, EventArgs e) 
		{
			errorMessage.SelectAll();
			errorMessage.Copy();
			errorMessage.DeselectAll();
		}
	}
}
