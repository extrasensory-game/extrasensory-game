namespace ExtrasensoryGame.Data
{
    using System.Collections.Generic;

    using SpiritDialogs;

    public class SpiritData
    {
        private SpiritDialog[] _avaliableDialogs;
        private int? nextDialog = 0;

        public SpiritData(SpiritDialog[] avaliableDialogs, IDictionary<int, float> goodsInfluence)
        {
            this._avaliableDialogs = avaliableDialogs;
        }

        public SpiritDialog GetNextDialog()
        {
            return nextDialog.HasValue ? _avaliableDialogs[nextDialog.Value] : null;
        }
    }
}