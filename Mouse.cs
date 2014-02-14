using System;
using System.Collections.Generic;

namespace iMouse
{
	public class Mouse
	{
		private DateTime dob;
		private int id;
		private LinkedList<Locus> loci;

		public Mouse(DateTime dob, int id)
		{
			this.dob = dob;
			this.id = id;
		}
		public double AgeMonth()
		{
			throw new NotImplementedException();
		}

		public double AgeDays()
		{
			throw new NotImplementedException();
		}

		public DateTime Dob { get {return this.dob; } }

		public bool AddLocus(Locus l) 
		{
			if (loci.Contains(l)) { 
				return false;
			} else {
				loci.AddLast(l);
				return true;
			}
		}

		public bool IsOmozigous()
		{
			throw NotImplementedException();
		}

		public bool IsOmozigous(string locus) 
		{
			foreach (Locus l in loci) {
				if (l.Name == locus) {
					return l.IsOmozigous();
				}
			}
			throw new Exception("Non existent locus accessed\n");
		}

		public Locus GetLocus(string locus)
		{
			foreach (Locus l in loci) {
				if (l.Name == locus) {
					return l;
				}
			}
			throw new Exception("Non existent locus accessed\n");
		}
		
		public override bool Equals(Object obj) 
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to Point return false.
			Mouse m = obj as Mouse;
			if ((System.Object)m == null)
			{
				return false;
			}
			// Return true if the fields match:
			return m.id == this.id;
		}
		public bool Equals(Mouse m)
		{
			// If parameter is null return false:
			if ((object)m == null)
			{
				return false;
			}
			// Return true if the fields match:
			return m.id == this.id;
		}

		public override int GetHashCode()
		{
			return id;
		}

		public override string ToString ()
		{
			return id + ", born on " + dob;
		}

}

