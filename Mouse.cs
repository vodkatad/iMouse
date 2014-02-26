using System;
using System.Collections.Generic;

namespace IMouse
{
	public class Mouse : IEquatable<Mouse>
	{
		private readonly DateTime dateOfBirth;
		private readonly int id;
		private List<Locus> loci;
		private readonly char sex;

		public Mouse(DateTime dob, int id, char sex)
		{
			if (sex != 'F' && sex != 'M') {
				throw new ArgumentOutOfRangeException("Mouse sex can only be M or F, given: " + sex);
			}
			this.dateOfBirth = dob;
			this.id = id;
			this.loci = new List<Locus>();
			this.sex = sex;
		}

		public double AgeMonth
		{
			get { throw new NotImplementedException(); }
		}

		public double AgeDays
		{
			get { throw new NotImplementedException(); }
		}

		public DateTime Dob 
		{ 
			get { 
				return this.dateOfBirth; 
			}
		}

		public char Sex {
			get {
				return sex;
			}
		}

		public bool AddLocus(Locus l) 
		{
			if (loci.Contains(l)) { 
				return false;
			} else {
				loci.Add(l);
				return true;
			}
		}

		public bool IsOmozigous(string locus) 
		{
			foreach (Locus l in loci) {
				if (l.Name == locus) {
					return l.IsOmozigous();
				}
			}
			throw new Exception("Non existent locus accessed");
		}

		public Locus GetLocus(string locus)
		{
			foreach (Locus l in loci) {
				if (l.Name == locus) {
					return l;
				}
			}
			throw new Exception("Non existent locus accessed");
		}
		
		public override bool Equals(Object obj) 
		{
			return Equals(obj as Mouse);
		}

		public bool Equals(Mouse m)
		{
			// If parameter is null return false:
			if (m == null) {
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
			return id + ", born on " + dateOfBirth + " sex: " + sex;
		}
	}
}

