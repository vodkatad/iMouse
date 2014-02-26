using System;
using Mono.Options;
using System.Collections.Generic;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace IMouse
{
	class MainClass
	{
		private static readonly string LOCUS_NAME = "simple";
		public static int Main (string[] args)
		{
			string fileName = "";
			bool showHelp = false;

			Console.WriteLine("Hello Mice World!");
			var p = new OptionSet {
				{ "f|file=", "the ods file",
					(string v) => fileName = v },
				{ "h|help", "show this message and exit",
					v => showHelp = v != null },
			};
			List<string> extraArgs;
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

			//https://github.com/tonyqus/npoi
			HSSFWorkbook wb = new HSSFWorkbook(new FileStream (fileName, FileMode.Open));
			ISheet sheet = wb.GetSheetAt(0);
			System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

			// We skip the first two rows with headers.
			rows.MoveNext();
			rows.MoveNext();
			int lastWantedCell = 5;
			// Each row is a cage.
			int id = 0;
			bool done = false;
			List<Cage> cages = new List<Cage> ();
			while (rows.MoveNext() && !done) {
				Cage cage = new Cage(id++);
				IRow row = (HSSFRow)rows.Current;
				string genotype = "";
				string sex = "";
				int amount = 0;
				DateTime dob = new DateTime();
				for (int i = 0; i < lastWantedCell; i++) {
					ICell cell = row.GetCell(i);
					//Console.WriteLine(cell + " working with this cell");
					if (cell == null) {
						if (i > 0) {
							throw new Exception(".xls with wrong structure given, I need " + lastWantedCell + " columns");
						}
						continue;
					} else {
						switch (i) {
						case 0:
							cage.Number = (int)cell.NumericCellValue;
							break;
						case 1: // genotype
							genotype = cell.StringCellValue;
							break;
						case 2: //sex
							sex = cell.StringCellValue;
							break;
						case 3: //amount
							amount = (int) cell.NumericCellValue;
							break;
						case 4: //date of birth
							dob = cell.DateCellValue;
							break;
						case 5:
							throw new Exception("Something really unespected have happened\n");
						}
					}
				}
				int mouse_id = 0;
				while (mouse_id < amount) {
					Mouse m = new Mouse(dob, mouse_id, sex.ToUpper().ToCharArray()[0]);
					m.AddLocus(GetSimpleLocus(genotype));
					mouse_id++;
					if (!cage.AddMouse(m)) {
						Console.Error.WriteLine("Mouse " + m + " cannot be loaded as long as it's already somewhere");
					}
				}
				cages.Add(cage);
			}
			foreach (Cage c in cages) {
				foreach (Mouse m in c) {
					Console.Write(m);
					Console.WriteLine(" Genotipo? " + m.IsOmozigous(LOCUS_NAME));
				}
			}
			return 0;
		}

		static Locus GetSimpleLocus(string l) {
			string patAllele = "";
			string matAllele = "";
			string name = LOCUS_NAME;
			if (l == "omo") {
				patAllele = matAllele = "-";
			} else if (l == "wt") {
				patAllele = matAllele = "+";
			} else {
				throw new ArgumentOutOfRangeException("Right now we handle only omo or wt loci!");
			}
			return new Locus(patAllele, matAllele, name);
		}

		static void ShowHelp(OptionSet p)
		{
			Console.WriteLine("Usage: {0} -f filename", Environment.GetCommandLineArgs()[0]);
			Console.WriteLine("Options:");
			p.WriteOptionDescriptions(Console.Out);
		}
	}
}
