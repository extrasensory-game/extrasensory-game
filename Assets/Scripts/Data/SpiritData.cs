using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace ExtrasensoryGame.Data
{
    using System.Collections.Generic;

    using SpiritDialogs;

    public class SpiritData
    {
        private float _rage = 0;

        public int Id;

        private string _name;
        private bool _isPremium;

        private List<SpiritPhrase> _avaliablePhrases;
        private int _nextDialogIndex = 0;

        private int[] _pleasantItemIds;

        public GameObject Prefab;

        public SpiritDialog[] Dialogs;

        public SpiritData(int id, SpiritPhrase[] phrases, bool isPremium, string name, int[] pleasantItemIds, int[] dialogIds)
        {
            Id = id;
            _avaliablePhrases = new List<SpiritPhrase>(phrases);
            _name = name;
            _isPremium = isPremium;
            _pleasantItemIds = pleasantItemIds;
        }
        
        public SpiritDialog GetNextDialog()
        {
            if (_nextDialogIndex + 1 < this.Dialogs.Length)
                return this.Dialogs[_nextDialogIndex++];

            return null;
        }

        public bool HasNextDialog()
        {
            return this._nextDialogIndex < this.Dialogs.Length;
        }

        public SpiritPhrase[] GetSpiritPhrases()
        {
            return this._avaliablePhrases.ToArray();
        }

        public void SelectPhrase(SpiritPhrase phrase)
        {
            this._rage += phrase.Points;
            this._avaliablePhrases.Remove(phrase);
        }

        public float ApplyItem(ItemData itemData)
        {
            this._rage += _pleasantItemIds.Any(ii => ii == itemData.Id) 
                ? itemData.RageAbsoluteModifier 
                : -itemData.RageAbsoluteModifier;
            return _rage;
        }

        public SpiritState GetState()
        {
            return _rage < -100 
                    ? SpiritState.CatchedPeaceful
                    : (_rage > 100 
                         ? SpiritState.CatchedAgressive 
                         : SpiritState.Neutral);
        }
    }
}