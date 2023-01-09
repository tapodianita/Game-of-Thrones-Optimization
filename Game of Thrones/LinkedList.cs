using System;
using System.Collections.Generic;
using System.Collections;

namespace Game_of_Thrones
{
	class ListElement<T>
	{
		public T Content { get; set; }
		public ListElement<T> Next { get; set; }
	}

	public class LinkedList<T> : IEnumerable<T>
	{
		private ListElement<T> Head;
		public void Insert(T content)
		{
			ListElement<T> newEl = new ListElement<T>();
			newEl.Content = content;
			newEl.Next = Head;
			Head = newEl;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new ListMethods<T>(Head);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ListMethods<T>(Head);
		}

	}
}
