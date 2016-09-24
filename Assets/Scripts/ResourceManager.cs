using UnityEngine;

namespace ExtrasensoryGame
{
    using Data;

    public class ResourceManager : MonoBehaviour
    {
        private ClientGenerator _clientGenerator;

        private SpiritData[] _spirits;

        private void Start()
        {
            this.LoadSpirits();
        }

        // TODO add API sufficient for any game mode script.

        public Client GetNextClient()
        {
            return _clientGenerator.GetClient();
        }

        private void LoadSpirits()
        {
            // TODO REALIZE THIS.
            this._spirits = new SpiritData[0];
        }
    }
}