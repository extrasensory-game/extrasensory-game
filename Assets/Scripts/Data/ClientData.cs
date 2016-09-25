using System;
using UnityEngine;
using System.Linq;

namespace ExtrasensoryGame.Data
{
    using Enums;

    [Serializable]
    public class ClientData : DataParser.LoadabelObject
    {
        public int Id;
        public string Name;
        public CharacterCharacteristic[] Attributes;

        public override void Init(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            Attributes = data[2].Split(',')
                .Select(attributeIdString => (CharacterCharacteristic)Int32.Parse(attributeIdString))
                .ToArray();
        }
    }
}