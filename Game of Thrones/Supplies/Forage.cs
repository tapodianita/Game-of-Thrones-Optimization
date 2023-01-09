namespace Game_of_Thrones
{

	/// <summary>
	/// Base class of forage.
	/// </summary>
	public abstract class Forage : Supply
	{
		public Forage(int unit, int price): base(unit, price) { }
	}



	public class Wheat : Forage
	{
		public Wheat(int unit, int price) : base(unit, price) { }

		public override Wheat UnitClone(int unit) {
			return new Wheat(unit, Price);
		}
	}

	public class Hay : Forage
	{
		public Hay(int unit, int price) : base(unit, price) { }

		public override Hay UnitClone(int unit) {
			return new Hay(unit, Price);
		}
	}

	public class Oats : Forage
	{
		public Oats(int unit, int price) : base(unit, price) { }

		public override Oats UnitClone(int unit) {
			return new Oats(unit, Price);
		}
	}

}
