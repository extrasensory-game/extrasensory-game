using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace ExtrasensoryGame.Data
{
    using System.Collections.Generic;

    using SpiritDialogs;

    public class SpiritData
    {
        public float Rage { get { return this._rage; } }
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
            if (_nextDialogIndex < this.Dialogs.Length)
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
            var rageModifierValue = _pleasantItemIds.Any(ii => ii == itemData.Id)
                ? itemData.RageAbsoluteModifier
                : -itemData.RageAbsoluteModifier;
            this._rage += rageModifierValue;
            return _rage;
        }

        public SpiritState GetState()
        {
                    ? SpiritState.CatchedPeaceful
                         ? SpiritState.CatchedAgressive 
                         : SpiritState.Neutral);
        }
    }
}