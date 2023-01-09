using Game_of_Thrones;

namespace Game_of_Thrones
{
	/// <summary>
	/// Base class of fruits.
	/// </summary>
	public abstract class Fruit : Supply
	{
		public Fruit(int unit, int price) : base(unit, price) { }
	}

	public class Apple : Fruit
	{
		public Apple(int unit, int price) : base(unit, price) { }

		public override Apple UnitClone(int unit)
		{
			return new Apple(unit, Price);
		}
	}

	public class Peach : Fruit
	{
		public Peach(int unit, int price) : base(unit, price) { }

		public override Peach UnitClone(int unit) {
			return new Peach(unit, Price);
		}
	}

	public class Grape : Fruit
	{
		public Grape(int unit, int price) : base(unit, price) { }

		public override Grape UnitClone(int unit) {
			return new Grape(unit, Price);
		}
	}

}
