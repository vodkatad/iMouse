using System;

namespace iMouse
{
	public class Locus
	{
		private string paternalAllele;
		private string maternalAllele;
		private string name;

		public Locus(string pAllele, string mAllele, string name)
		{
			paternalAllele = pAllele;
			maternalAllele = mAllele;
			this.name = name;
		}
		public string Name { get { return this.name; } } 

		public bool IsOmozigous()
		{
			return paternalAllele == maternalAllele;
		}
	}
}

