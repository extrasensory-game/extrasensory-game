using System.Linq;
using ExtrasensoryGame.Data;
using ExtrasensoryGame.Data.SpiritDialogs;
using UnityEngine;

namespace ExtrasensoryGame
{
    public class ResourceManager : MonoBehaviour
    {
        private SpiritPhrase[] _spiritPhrases;
        private SpiritData[] _spirits;
        private ItemData[] _items;

        [SerializeField]
        private GameObject[] _spiritPrefabs;

        private ClientGenerator _clientGenerator = new ClientGenerator();

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            LoadSpiritPhrases();
            LoadSpirits();
            LoadItems();
        }

        private void LoadItems()
        {
            _items = DataParser.LoadItems();
        }

        public Client GetNextClient()
        {
            return _clientGenerator.GetClient();
        }

        public SpiritData GetRandomSpirit()
        {
            return _spirits[Random.Range(0, _spirits.Length)];
        }

        private void LoadSpirits()
        {
            var spirits = DataParser.LoadSpiritsData();

            _spirits = new SpiritData[spirits.Length];
            for (int i = 0; i < _spirits.Length; i++)
            {
                var phrases = _spiritPhrases.Where(p => spirits[i].Phrases.Contains(p.Id)).ToArray();
                _spirits[i] = new SpiritData(spirits[i].Id, phrases, spirits[i].IsPremium, spirits[i].Name, spirits[i].PleasantItemIds);
                _spirits[i].Prefab = _spiritPrefabs[i];
            }
        }

        private void LoadSpiritPhrases()
        {
            var speachTexts = DataParser.LoadSpeachTexts();
            var replayTexts = DataParser.LoadReplayTexts();
            var phraseDatas = DataParser.LoadPhrases();

            _spiritPhrases = new SpiritPhrase[phraseDatas.Length];
            for (int i = 0; i < phraseDatas.Length; i++)
            {
                var speach = speachTexts.First(s => s.Id == phraseDatas[i].SpeachTextId);
                var replay = replayTexts.First(s => s.Id == phraseDatas[i].ReplayTextId);
                _spiritPhrases[i] = new SpiritPhrase
                {
                   Id =  phraseDatas[i].Id,
                   Speach = speach.Text,
                   Replay = replay.Text,
                   Points = speach.Points
                };
            }
        }

        public ItemData[] GetItems()
        {
            if (_items == null)
                LoadItems();

            return _items;
        }
    }
}