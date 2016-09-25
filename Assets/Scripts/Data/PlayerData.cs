using ExtrasensoryGame.Enums;

namespace ExtrasensoryGame
{
    using Data;

	public class PlayerData 
	{
		public Client CurrentClient;
		public float MagicPower = 100;
        public ItemData[] Items;

	    public void AddItem(ItemData item)
	    {
	        var items = new ItemData[Items.Length + 1];
	        for (int i = 0; i < Items.Length; i++)
	        {
	            items[i] = Items[i];
	        }

	        items[items.Length - 1] = item;
	        Items = items;
	    }
	}
}
