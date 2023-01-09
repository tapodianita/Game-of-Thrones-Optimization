using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones
{
	public class Houses : LinkedList<Supply>
	{
		private const bool DetailedDescription = true;

		public string Name;
		public int RequestedQuantity;
		public int RemainedQuantity => RequestedQuantity - SomOfUnints;
		public int SomOfUnints
		{
			get
			{
				int sum = 0;
				foreach (Supply supply in this)
				{
					sum += supply.Unit;
				}
				return sum;
			}
		}

		public Houses(string name, int requestedQuantity)
		{
			Name = name;
			RequestedQuantity = requestedQuantity;
		}

		public void AddSupply(Supply supply)
		{
			if (!IsPreference(supply))
			{
				throw new Exception("The given supply is not a preference of the house. [ Type of supply: " + supply.GetType().Name + " ]");
			}
			else
			{
				SameTypeSupplyFromStorage(supply).Unit += supply.Unit;
			}
		}

		public Supply SameTypeSupplyFromStorage(Supply supply)
		{
			Type type = supply.GetType();
			foreach (Supply storage in this)
			{
				if (storage.GetType() == type)
				{
					return storage;
				}
			}
			return null;
		}

		public bool IsPreference(Supply supply)
		{
			return SameTypeSupplyFromStorage(supply) != null;
		}

		public override string ToString()
		{
			string text = Name + " ( " + SomOfUnints + " / " + RequestedQuantity + ")";
			if (DetailedDescription)
			{
				text += ": [ ";
				int i = 0;
				foreach (Supply supply in this)
				{
					if (i > 0)
					{
						text += " , ";
					}
					text += supply.GetType().Name + " = " + supply.Unit;
					i++;
				}
				text += " ]";
			}
			return text;
		}

	}
}
