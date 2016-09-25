using System;
using UnityEngine;
using System.Linq;

namespace ExtrasensoryGame.Data.SpiritDialogs
{
    public class SpiritDialog : DataParser.LoadabelObject
    {
        public int Id;
        public string Text;
        public SpiritPhrase[] Pharases;

        private int[] _phraseIds;

        public override void Init(string[] data)
        {
            this.Id = Int32.Parse(data[0]);
            this.Text = data[1];
            this._phraseIds = data[2].Split(',').Select(phraseIdStr => Int32.Parse(phraseIdStr)).ToArray();
        }

        public void InitPhrases(SpiritPhrase[] allPhrases)
        {
            this.Pharases = allPhrases.Where(phrase => this._phraseIds.Contains(phrase.Id)).ToArray();
        }
    }
}