using System.Linq;
using ExtrasensoryGame.Enums;

namespace ExtrasensoryGame
{
    using Data;

	public class PlayerData 
	{
		public Client CurrentClient;
		public float MagicPower = 100;
        public ItemData[] Items;
	    public int Money = 20;
	    public int HumanityPoints = 40;
	    public int QuackPoints = 5;
	    public int SpiritPoints = 0;

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

        public ItemData[] GetArtifacts()
        {
            return Items.Where(i => i.Type == ItemData.ItemDataType.artifact).ToArray();
        }
        public ItemData[] GetMedCheats()
        {
            return Items.Where(i => i.Type == ItemData.ItemDataType.medCheat).ToArray();
        }
    }
}
