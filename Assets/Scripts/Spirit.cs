using System;
using UnityEngine;

namespace ExtrasensoryGame.Data
{
    using SpiritDialogs;

    public class Spirit
    {
        public event Action<float> OnRageChanged;
        public event Action<SpiritState> OnStateChanged;

        private SpiritData _spiritData;

        public GameObject Prefab { get { return this._spiritData.Prefab; } }

        public void Initialize(SpiritData spiritData)
        {
            this._spiritData = spiritData;
        }

        public void ApplyItem(ItemData itemData)
        {
            var rageValue = this._spiritData.ApplyItem(itemData);

            this.UpdateRageBar();
            if (StateChanged())
                ApplyStateChanges();
        }

        public SpiritDialog GetNextDialog()
        {
            return this._spiritData.GetNextDialog();
        }

        public void SelectPhrase(SpiritPhrase phrase)
        {
            this._spiritData.SelectPhrase(phrase);
            this.UpdateRageBar();
            if (StateChanged())
                ApplyStateChanges();
        }

        private void UpdateRageBar()
        {
            if (OnRageChanged != null)
                this.OnRageChanged(this._spiritData.Rage);
        }

        private SpiritState prevSpiritState = SpiritState.Neutral;
        private bool StateChanged()
        {
            var currentState = this._spiritData.GetState();
            var changed = prevSpiritState != currentState;
            this.prevSpiritState = currentState;

            return changed;
        }

        private void ApplyStateChanges()
        {
            if (OnStateChanged != null)
                OnStateChanged(this._spiritData.GetState());
        }
    }
}