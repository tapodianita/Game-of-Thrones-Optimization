namespace Game_of_Thrones
{
	/// <summary>
	/// Base class of beverages.
	/// </summary>
	public abstract class Beverages : Supply
	{
		public Beverages(int unit, int price) : base(unit, price) { }
	}



	public class Wine : Beverages
	{
		public Wine(int unit, int price) : base(unit, price) { }

		public override Wine UnitClone(int unit) {
			return new Wine(unit, Price);
		}
	}

	public class Beer : Beverages
	{
		public Beer(int unit, int price) : base(unit, price) { }

		public override Beer UnitClone(int unit) {
			return new Beer(unit, Price);
		}
	}

}
