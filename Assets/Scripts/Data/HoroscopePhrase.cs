using UnityEngine;
using System.Collections;
using System;

namespace ExtrasensoryGame.Data
{
    public class HoroscopePhrase : DataParser.LoadabelObject
    {
        public int Id;
        public string Text;
        public float RageModifierValue;

        public override void Init(string[] data)
        {
            this.Id = Int32.Parse(data[0]);
            this.Text = data[1];
            this.RageModifierValue = Single.Parse(data[2]);
        }
    }
}