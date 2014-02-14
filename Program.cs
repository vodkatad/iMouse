using System;
using Mono.Options;
using System.Collections.Generic;

namespace iMouse
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string fileName = "";
			bool showHelp = false;

			Console.WriteLine("Hello World!");
			var p = new OptionSet () {
				{ "f|file=", "the ods file",
					(string v) => file = v },
				{ "h|help", "show this message and exit",
					v => showHelp = v != null },
			};
			List<string> extraArgs = null;
			try {
				extraArgs = p.Parse(args);
			} catch (OptionException oe) {
				Console.Error.WriteLine(oe.Message);
				return -1;
			}
			if (extraArgs.Count != 0 || fileName == "") {
				ShowHelp(p);
				return -1;
			}
			if (showHelp) {
				ShowHelp(p);
				return 0;
			}

			//https://github.com/paulyoder/LinqToExcel	
			//http://www.gemboxsoftware.com/SampleExplorer/Spreadsheet/CommonUses/Reading?tab=cs
		}

		static void ShowHelp(OptionSet p)
		{
			Console.WriteLine("Usage: {0} -f filename", Environment.GetCommandLineArgs()[0]);
			Console.WriteLine("Options:");
			p.WriteOptionDescriptions(Console.Out);
		}
	}
}
