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

		public override bool Equals(Object obj) 
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to Point return false.
			Locus l = obj as Locus;
			if ((System.Object)l == null)
			{
				return false;
			}
			// Return true if the fields match:
			return l.name == this.name && l.paternalAllele == this.maternalAllele && l.paternalAllele == this.paternalAllele;
		}
		public bool Equals(Locus l)
		{
			if ((System.Object)l == null)
			{
				return false;
			}
			// Return true if the fields match:
			return l.name == this.name && l.paternalAllele == this.maternalAllele && l.paternalAllele == this.paternalAllele;
		}

		public override int GetHashCode()
		{
			return GetHashCode(name) + GetHashCode(paternalAllele) + GetHashCode(maternalAllele);
		}
	}
}

