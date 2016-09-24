using UnityEngine;

namespace ExtrasensoryGame.Data
{
    public class Spirit : MonoBehaviour
    {
        private SpiritData _spiritData;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(SpiritData spiritData)
        {
            this._spiritData = spiritData;
        }

        public void ApplyItem(int itemId)
        {
            var rageValue = this._spiritData.ApplyItem(itemId);

            // TODO Set rage on slider.
            if (StateChanged())
                ApplyStateChanges();
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