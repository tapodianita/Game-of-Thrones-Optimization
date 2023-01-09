using System;
using System.Collections.Generic;

namespace Game_of_Thrones
{
	class Program
	{
		/// <summary>
		/// During the generation of<see cref="RoyalTreasury">Royal Treasury</see> <see cref="Supply">Supply</see> supplies will be available at least in this amount.
		/// </summary>
		///
		private const int MinUnit = 100;
		/// <summary>
		/// During the generation of Royal Treasury,<see cref="RoyalTreasury">Royal Treasury</see><see cref="Supply">Supply</see> this will be the highest amount of available supplies.
		/// </summary>
		private const int MaxUnit = 10000;
		/// <summary>
		/// During the generation of Royal Treasury,<see cref="RoyalTreasury">Royal Treasury</see><see cref="Supply">Supply</see> this will be the lowest unit price of supplies.
		/// </summary>
		private const int MinPrice = 100;
		/// <summary>
		/// During the generation of Royal Treasury,<see cref="RoyalTreasury">Royal Treasury<see cref="Supply">Supply</see> this will be the highest unit price of supplies.
		/// </summary>
		private const int MaxPrice = 1000;
		/// <summary>
		/// During the generation of Royal Treasury,<see cref="HousesOfWesteros">Houses</see> this amount will be the highest demand of every House..
		/// </summary>
		private const int MaxNeed = 1000;

		/// <summary>
		/// Names of Westeros Royal Houses.
		/// </summary>
		private readonly static string[] NameOfHouses = { "Tully", "Arryn", "Martell", "Baratheon", "Tyrell", "Greyjoy", "Lannister", "Targaryen", "Stark" };

		/// <summary>
		/// Random Number Generator.
		/// </summary>
		private static Random RNG = new Random();
		private static Supply[] RoyalTreasury;
		private static BinarySearchTree<Houses, int> HousesOfWesteros = new BinarySearchTree<Houses, int>();

		public static void Main(string[] args)
		{
			GenerationOfRoyalTreasury();
			RoyalTreasuryWrite();

			GenerateHouses();
			Console.WriteLine("Royal Houses of Westeros:");
			Console.WriteLine(HousesOfWesteros);

			Console.WriteLine("-------------------------------------------------");
			Console.WriteLine("Distribution of Supplies");
			if (!DistributionOfSupplies())
			{
				throw new CannotDivideException();
			}


			Console.WriteLine("-------------------------------------------------");
			RoyalTreasuryWrite();
			Console.WriteLine("Royal Houses of Westeros:");
			Console.WriteLine(HousesOfWesteros);

			Console.ReadLine();
		}

		private static void StockReplenishmentOfRoyalWareHouse()
		{
			RoyalTreasury = new Supply[]
			{
				new Apple(1000000, 170),
				new Peach(200000, 400),
				new Grape(1000000, 500),
				new Goat(45000, 150),
				new Cattle(100000, 350),
				new Pig(30000, 300),
				new Wine(100000, 370),
				new Beer(450000, 170),
				new Oats(250000, 300),
				new Wheat(100000, 100),
				new Hay(150000, 150)
			};
		}

		/// <summary>
		/// Generates randomly the content of <see cref="RoyalTreasury">Royal Treasury</see>The Royal Treasury.
		/// </summary>
		private static void GenerationOfRoyalTreasury()
		{
			RoyalTreasury = new Supply[]
			{
				new Apple(RandomUnit(), RandomPrice()),
				new Peach(RandomUnit(), RandomPrice()),
				new Grape(RandomUnit(), RandomPrice()),
				new Goat(RandomUnit(), RandomPrice()),
				new Cattle(RandomUnit(), RandomPrice()),
				new Pig(RandomUnit(), RandomPrice()),
				new Wine(RandomUnit(), RandomPrice()),
				new Beer(RandomUnit(), RandomPrice()),
				new Oats(RandomUnit(), RandomPrice()),
				new Wheat(RandomUnit(), RandomPrice()),
				new Hay(RandomUnit(), RandomPrice()),
			};
		}

		private static void RoyalTreasuryWrite()
		{
			Console.WriteLine("The content of the Royal Treasury:");
			foreach (Supply supply in RoyalTreasury)
			{
				Console.WriteLine("\t" +
					supply.GetType().Name
					+ "\t\tsum of "
					+ supply.Unit
					+ " units, "
					+ supply.Price
					+ " gold / unit\t>>\ttotal "
					+ (supply.Unit * supply.Price)
					+ " gold");
			}
			Console.WriteLine();
		}

		/// <summary>
		/// Generates randomly the <see cref="HousesOfWesteros">Houses</see>.
		/// </summary>
		private static void GenerateHouses()
		{
			List<string> names_of_houses = new List<string>(NameOfHouses);

			List<int> numbers = new List<int>();
			for (int i = 1; i <= RoyalTreasury.Length; i++)
			{
				numbers.Add(i);
			}

			int index = 1;
			while (names_of_houses.Count > 0)
			{
				int name_index = RNG.Next(0, names_of_houses.Count);
				Houses house = new Houses(names_of_houses[name_index], RNG.Next(1, MaxNeed + 1));
				names_of_houses.RemoveAt(name_index);

				int num_index = RNG.Next(0, numbers.Count);
				int preference_number = numbers[num_index];
				numbers.RemoveAt(num_index);

				List<Supply> remained_preferencies = new List<Supply>(RoyalTreasury);
				for (int i = 0; i < preference_number; i++)
				{
					int type_index = RNG.Next(0, remained_preferencies.Count);
					house.Insert(remained_preferencies[type_index].UnitClone(0));
					remained_preferencies.RemoveAt(type_index);
				}
				HousesOfWesteros.Insert(preference_number, house);

				index++;
			}

		}

		/// <summary>
		/// Attends to distribute <see cref="RoyalTreasury">Royal Treasury</see> the supplies among the <see cref="HousesOfWesteros">Houses</see>.
		/// </summary>
		/// <returns>
		/// - TRUE: if succeeded<br/>
		/// - FALSE: if failed
		/// </returns>
		private static bool DistributionOfSupplies()
		{
			for (int i = 1; i <= RoyalTreasury.Length; i++)
			{
				Houses house = HousesOfWesteros.Leker(i);
				if (house == null)
				{
					continue;
				}

				foreach (Supply supply in RoyalTreasury)
				{
					if (house.IsPreference(supply) && supply.Unit > 0)
					{
						int unit = Math.Min(supply.Unit, house.RemainedQuantity);
						Supply clone = supply.UnitClone(unit);
						house.AddSupply(clone);
						supply.Unit -= clone.Unit;
					}
				}
				if (house.RemainedQuantity > 0)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Generate a random integer within the intervals of static minimum and maximum units.
		/// </summary>
		/// <returns>Generated value.</returns>
		private static int RandomUnit()
		{
			return RNG.Next(MinUnit, MaxUnit + 1);
		}
		private static int RandomPrice()
		{
			return RNG.Next(MinPrice, MaxPrice + 1);
		}

	}
}
