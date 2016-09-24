using System;
using UnityEngine;

namespace ExtrasensoryGame.Data
{
    [Serializable]
    public class ItemData : DataParser.LoadabelObject
    {
        public int Id;
        public string Name;
        public float RageAbsoluteModifier;

        public override void Init(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            RageAbsoluteModifier = Single.Parse(data[2]);            
        }
    }
}