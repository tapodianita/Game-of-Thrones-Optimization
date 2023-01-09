using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
		class ListMethods<T> : IEnumerator<T>
		{
			ListElement<T> Head;
			ListElement<T> Actual = new ListElement<T>();

			public ListMethods(ListElement<T> head)
			{
				Head = head;
				Actual.Next = Head;
			}

			public object Current
			{
				get
				{
					return Actual.Content;
				}
			}

			T IEnumerator<T>.Current
			{
				get
				{
					return Actual.Content;
				}
			}

			public void Dispose()
			{

			}
			public bool MoveNext()
			{
				if (Actual == null)
				{
					return false;
				}
				Actual = Actual.Next;
				return Actual != null;
			}

			public void Reset()
			{
				Actual = new ListElement<T>();
				Actual.Next = Head;
			}
	}
}
