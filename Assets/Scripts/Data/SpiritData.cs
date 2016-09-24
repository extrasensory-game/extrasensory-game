namespace ExtrasensoryGame.Data
{
    using System.Collections.Generic;

    using SpiritDialogs;

    public class SpiritData
    {
        private float _rage = 0;

        private SpiritDialog[] _avaliableDialogs;
        private int _nextDialogIndex = 0;

        private IDictionary<int, float> _itemsInfluence;

        public SpiritData(SpiritDialog[] avaliableDialogs, IDictionary<int, float> itemsInfluence)
        {
            this._avaliableDialogs = avaliableDialogs;
            this._itemsInfluence = itemsInfluence;
        }

        public bool HasNextDialog()
        {
            return this._nextDialogIndex < this._avaliableDialogs.Length;
        }

        public SpiritDialog GetNextDialog()
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