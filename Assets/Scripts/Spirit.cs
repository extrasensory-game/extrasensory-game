using UnityEngine;

namespace ExtrasensoryGame.Data
{
    using SpiritDialogs;

    public class Spirit : MonoBehaviour
    {
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
        }

        private void UpdateRageBar()
        {
            // TODO.
        }

        private SpiritState prevSpiritState = SpiritState.Neutral;
        private bool StateChanged()
        {
            var currentState = this._spiritData.GetState();
            var changed = prevSpiritState == currentState;
            this.prevSpiritState = currentState;

            return changed;
        }

        private void ApplyStateChanges()
        {
            // Make ghost red or white and raise some events (interesting for game mode).
        }
    }
}