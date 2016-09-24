using UnityEngine;

namespace ExtrasensoryGame.Data
{
    using SpiritDialogs;

    public class Spirit : MonoBehaviour
    {
        private SpiritData _spiritData;

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

        public SpiritPhrase[] GetSpiritPhrases()
        {
            return this._spiritData.HasNextDialog() ? this._spiritData.GetSpiritPhrases() : new SpiritPhrase[0];
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