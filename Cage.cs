using System;
using System.Collections;
using System.Collections.Generic;

namespace iMouse
{
	public class Cage : IEnumerable
	{
		private LinkedList<Mouse> mice;
		private int id;

		public Cage(int id)
		{
			this.id = id;
		}
		public int Occupancy {
			get { return mice.Count; }
		}

		public bool AddMouse(Mouse m) 
		{
			if (mice.Contains(m)) {
				return false;
			} else {
				mice.AddLast(m);
				return true;
			}
		}

		public bool RemoveMouse(Mouse m) 
		{
			if (!mice.Contains(m)) { 
				return false;
			} else {
				mice.RemoveFirst(m);
				return true;
			}
		}

		public int Id { get {return this.id;} }

		public IEnumerator GetEnumerator()
		{
			return mice.GetEnumerator();
		}


	}
}

