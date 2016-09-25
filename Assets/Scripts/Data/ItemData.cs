using System;

namespace ExtrasensoryGame.Data
{
    [Serializable]
    public class ItemData : DataParser.LoadabelObject
    {
        public int Id;
        public string Name;
        public float RageAbsoluteModifier;
        public int Price;
        public ItemDataType Type;

        public override void Init(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            RageAbsoluteModifier = Single.Parse(data[2]);
            Price = int.Parse(data[4]);
            Type = data[3] == ItemDataType.artifact.ToString() ? ItemDataType.artifact : ItemDataType.medCheat;
        }   

        public enum ItemDataType
        {
            artifact,
            medCheat
        }
    }
}