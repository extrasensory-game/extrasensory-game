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

        private ClientGenerator _clientGenerator = new ClientGenerator();

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            LoadSpiritPhrases();
            LoadSpirits();
        }

        public Client GetNextClient()
        {
            return _clientGenerator.GetClient();
        }

        private void LoadSpirits()
        {
            var spirits = DataParser.LoadSpiritsData();

            _spirits = new SpiritData[spirits.Length];
            for (int i = 0; i < _spirits.Length; i++)
            {
                var phrases = _spiritPhrases.Where(p => spirits[i].Phrases.Contains(p.Id)).ToArray();
                _spirits[i] = new SpiritData(spirits[i].Id, phrases, spirits[i].IsPremium, spirits[i].Name, spirits[i].PleasantItemIds);
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
    }
}