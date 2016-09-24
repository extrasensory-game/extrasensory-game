using System.Runtime.InteropServices;

namespace ExtrasensoryGame.Data
{
    using System.Collections.Generic;

    using SpiritDialogs;

    public class SpiritData
    {
        private float _rage = 0;

        private int _id;
        private string _name;
        private bool _isPremium;

        private SpiritPhrase[] _avaliableDialogs;
        private int _nextDialogIndex = 0;

        private IDictionary<int, float> _itemsInfluence;

        public SpiritData(int id, SpiritPhrase[] avaliableDialogs, bool isPremium, string name)
        {
            _id = id;
            _avaliableDialogs = avaliableDialogs;
            _name = name;
            _isPremium = isPremium;
        }

        public SpiritData(SpiritPhrase[] avaliableDialogs, IDictionary<int, float> itemsInfluence)
        {
            _avaliableDialogs = avaliableDialogs;
            _itemsInfluence = itemsInfluence;
        }

        public bool HasNextDialog()
        {
            return this._nextDialogIndex < this._avaliableDialogs.Length;
        }

        public SpiritPhrase GetNextDialog()
        {
            var currentDialog = HasNextDialog()
                 ? this._avaliableDialogs[this._nextDialogIndex++]
                 : null;

            return currentDialog;
        }

        public float ApplyItem(int itemId)
        {
            this._rage += _itemsInfluence.ContainsKey(itemId) ? _itemsInfluence[itemId] : 0;
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