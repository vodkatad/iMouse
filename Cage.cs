using System;
using System.Collections;

namespace iMouse
{
	public class Cage : IEnumerable
	{
		private Mouse[] mice; // LinkedList could work too, we do not need direct access.
		private int id;

		public Cage(int id)
		{
			this.id = id;
		}
		public int Occupancy {
			get { return mice.Length; }
		}

		public bool AddMouse(Mouse m) {
			throw NotImplementedException();
		}

		public bool RemoveMouse(Mouse m) {
			throw NotImplementedException();
		}

		public int Id { get {return this.id;} }

		public IEnumerator GetEnumerator()
		{
			return new MiceEnumerator(this);
		}

		private class MiceEnumerator : IEnumerator
		{
			private int position = -1;
			private Cage c;

			public MiceEnumerator(Cage c)
			{
				this.c = c;
			}

			// Declare the MoveNext method required by IEnumerator:
			public bool MoveNext()
			{
				if (position < c.mice.Length - 1) {
					position++;
					return true;
				} else {
					return false;
				}
			}

			// Declare the Reset method required by IEnumerator:
			public void Reset()
			{
				position = -1;
			}

			// Declare the Current property required by IEnumerator:
			// Explicit interface implementation in order to have also the next one (typesafe).
			public object IEnumerator.Current
			{
				get
				{
					return c.mice[position];
				}
			}

			public Mouse Current
			{
				get
				{
					return c.mice[position];
				}
			}
		}
	}
}

