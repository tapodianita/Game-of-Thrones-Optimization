namespace Game_of_Thrones
{
	public abstract class Supply
	{
		public int Unit;
		public int Price;

		protected Supply(int unit, int price)
		{
			Unit = unit;
			Price = price;
		}
		public abstract Supply UnitClone(int unit);

	}

}
