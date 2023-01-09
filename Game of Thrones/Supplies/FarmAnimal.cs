namespace Game_of_Thrones
{

	/// <summary>
	/// Base class of farm animals.
	/// </summary>
	public abstract class FarmAnimal : Supply
	{
		public FarmAnimal(int unit, int price) : base(unit, price) { }
	}



	public class Pig : FarmAnimal
	{
		public Pig(int unit, int price) : base(unit, price) { }

		public override Pig UnitClone(int unit) {
			return new Pig(unit, Price);
		}
	}

	public class Goat : FarmAnimal
	{
		public Goat(int unit, int price) : base(unit, price) { }

		public override Goat UnitClone(int unit) {
			return new Goat(unit, Price);
		}
	}

	public class Cattle : FarmAnimal
	{
		public Cattle(int unit, int price) : base(unit, price) { }

		public override Cattle UnitClone(int unit) {
			return new Cattle(unit, Price);
		}
	}

}

