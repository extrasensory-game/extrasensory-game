﻿using System.Linq;
using ExtrasensoryGame.Data;
using ExtrasensoryGame.Data.SpiritDialogs;
using UnityEngine;

namespace ExtrasensoryGame
{
    public class ResourceManager : MonoBehaviour
    {
        private SpiritDialog[] _spiritDialogs;
        private SpiritPhrase[] _spiritPhrases;
        private SpiritData[] _spirits;
        private ItemData[] _items;
        private ClientData[] _clients;
        private HoroscopePhrase[] _horoscopePhrases;

        [SerializeField]
        private GameObject[] _spiritPrefabs;

        [SerializeField]
        private ClientGenerator _clientGenerator;

        private int clientIndex = 0;        

        private void Start()
        {
            Init();
        }

        public void Init()
        {
            LoadSpiritPhrases();
            LoadSpiritDialogs();
            LoadSpirits();
            LoadItems();
            LoadClients();
            LoadHoroscopePhrases();
        }

        private void LoadItems()
        {
            _items = DataParser.LoadItems();
        }

        private void LoadClients()
        {
            _clients = DataParser.LoadClients();
        }

        private void LoadSpiritDialogs()
        {
            _spiritDialogs = DataParser.LoadSpiritDialogs();
            foreach (var dialog in _spiritDialogs)
                dialog.InitPhrases(_spiritPhrases);
        }

        private void LoadHoroscopePhrases()
        {
            this._horoscopePhrases = DataParser.LoadHoroscopePhrases();
        }

        public Client GetNextClient()
        {
            if (clientIndex >= _clients.Length)
                return null;

            var client = _clientGenerator.GetClient();
            client.ClientData = _clients[clientIndex++];
            return client;
        }

        public SpiritDialog GetNextDialogForSpirit(int spiritId)
        {
            return this._spirits.First(spirit => spirit.Id == spiritId).GetNextDialog();
        }

        public Spirit GetRandomSpirit()
        {
            var spirit = new Spirit();
            spirit.Initialize(_spirits[Random.Range(0, _spirits.Length)]);
            return spirit;
        }

        private void LoadSpirits()
        {
            if(_spiritPrefabs.Length == 0)
                return;
            var spirits = DataParser.LoadSpiritsData();

            _spirits = new SpiritData[spirits.Length];
            for (int i = 0; i < _spirits.Length; i++)
            {
                var phrases = _spiritPhrases.Where(p => spirits[i].Phrases.Contains(p.Id)).ToArray();
                _spirits[i] = new SpiritData(spirits[i].Id, phrases, spirits[i].IsPremium, spirits[i].Name, spirits[i].PleasantItemIds, spirits[i].DialogIds);
                _spirits[i].Dialogs = this._spiritDialogs.Where(dialog => spirits[i].DialogIds.Contains(dialog.Id)).ToArray();
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

        public ItemData[] LoadArtifactItems()
        {
            if(_items == null)
                LoadItems();

            return _items.Where(i => i.Type == ItemData.ItemDataType.artifact).ToArray();
        }

        public ItemData[] LoadMedCheatsItems()
        {
            if(_items == null)
                LoadItems();

            return _items.Where(i => i.Type == ItemData.ItemDataType.medCheat).ToArray();
        }

        private System.Random random = new System.Random();
        public HoroscopePhrase[] GetRandomHoroscopePhrases()
        {
            const int phrasesCount = 7;
            if (_horoscopePhrases.Length < phrasesCount)
                return _horoscopePhrases.OrderBy(ph => random.Next()).ToArray();

            return _horoscopePhrases.OrderBy(ph => random.Next()).Take(phrasesCount).ToArray();
        }
    }
}