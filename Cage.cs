using System;
using System.Collections;
using System.Collections.Generic;

namespace IMouse
{
	public class Cage : IEnumerable
	{
		private readonly List<Mouse> mice;
		private readonly int id;
		private int number;

		public Cage(int id)
		{
			this.id = id;
			this.mice = new List<Mouse>();
			this.number = -1;
		}
		public int Occupancy {
			get { return mice.Count; }
		}

		public bool AddMouse(Mouse m) 
		{
			if (mice.Contains(m)) {
				return false;
			} else {
				mice.Add(m);
				return true;
			}
		}

		public bool RemoveMouse(Mouse m) 
		{
			return mice.Remove(m);
		}

		public int Id {
			get { return this.id; } 
		}

		// Stupid "write once" property to be able to instantiate a Cage while loading mice data.
		public int Number {
			get {
				return number;
			}
			set {
				if (number != -1) {
					throw new InvalidOperationException ("Cage number can be set only once");
				}
				number = value;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return mice.GetEnumerator();
		}
	}
}

