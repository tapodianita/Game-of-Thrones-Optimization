using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
	public class BinarySearchTree<T, K> where K : IComparable
	{
		private class TreeElement
		{
			public K Key { get; set; }
			public T Content;
			public TreeElement Left;
			public TreeElement Right;

			public string AsString(int tab = 1, int mode = 0)
			{
				string text = "";

				if (Right != null)
				{
					text += Right.AsString(tab + 1, +1);
				}

				for (int i = 0; i < tab; i++)
				{
					text += "    ";
				}
				text += "[ " + Key + " ] = " + Content.ToString() + "\n";

				if (Left != null)
				{
					text += Left.AsString(tab + 1, -1);
				}

				return text;
			}

			public T Query(K key)
			{
				if (Key.CompareTo(key) < 0)
				{
					if (Right != null)
					{
						return Right.Query(key);
					}
				}
				else if (Key.CompareTo(key) > 0)
				{
					if (Left != null)
					{
						return Left.Query(key);
					}
				}
				else
				{
					return Content;
				}
				return default(T);
			}

		}

		private TreeElement Root;

		public void Insert(K key, T elem)
		{
			TreeElement insert = new TreeElement();
			insert.Key = key;
			insert.Content = elem;
			_Insert(ref Root, insert);
		}

		private void _Insert(ref TreeElement elem, TreeElement insert)
		{
			if (elem == null)
			{
				elem = insert;
			}
			else if (elem.Key.CompareTo(insert.Key) < 0)
			{
				_Insert(ref elem.Right, insert);
			}
			else if (elem.Key.CompareTo(insert.Key) > 0)
			{
				_Insert(ref elem.Left, insert);
			}
		}
		public T Leker(K key)
		{
			return Root.Query(key);
		}

		public override string ToString()
		{
			if (Root == null)
			{
				return "NULL";
			}
			else
			{
				return Root.AsString();
			}
		}

	}
}
