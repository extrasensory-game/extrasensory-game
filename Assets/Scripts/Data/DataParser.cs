using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ExtrasensoryGame.Data
{
    public static class DataParser
    {
        private const string SpeachFile = "Speach";
        private const string ReplaysFile = "Replays";
        private const string SpiritPhrasesFile = "SpiritPhrases";
        private const string SpiritFile = "Spirit";

        public static SpiritData[] LoadSpiritsData()
        {
            return LoadTexts(SpiritFile, () => new SpiritData()).Select(d => (SpiritData)d).ToArray();
        }

        public static PhraseData[] LoadPhrases()
        {
            return LoadTexts(SpiritPhrasesFile, () => new PhraseData()).Select(d => (PhraseData)d).ToArray();
        }

        public static TextData[] LoadSpeachTexts()
        {
            return LoadTexts(SpeachFile, () => new TextData()).Select(d => (TextData)d).ToArray();
        }

        public static TextData[] LoadReplayTexts()
        {
            return LoadTexts(ReplaysFile, () => new TextData()).Select(d => (TextData)d).ToArray();
        }

        private static LoadabelObject[] LoadTexts(string fileName, Func<LoadabelObject> getObjetInstance)
        {
            var res = Resources.Load(fileName);
            var text = (TextAsset)res;
            List<LoadabelObject> resultList = new List<LoadabelObject>();
            using(StringReader reader = new StringReader(text.text))
            {
                string line = reader.ReadLine();
                while(!string.IsNullOrEmpty(line))
                {
                    var items = line.Split(';');
                    if(!string.IsNullOrEmpty(items[0]) &&  items.Length > 1 && items[0] != "id")
                    {
                        var @object = getObjetInstance();
                        @object.Init(items);
                        resultList.Add(@object);
                    }

                    line = reader.ReadLine();
                }
            }

            return resultList.ToArray();
        }


        public abstract class LoadabelObject
        {
            public abstract void Init(string[] data);
        }


        [Serializable]
        public class TextData : LoadabelObject
        {
            public int Id;
            public string Text;
            public float Points;

            public override void Init(string[] data)
            {
                Id = int.Parse(data[0]);
                Text = data[1];
                Points = float.Parse(data[2]);
            }
        }

        [Serializable]
        public class PhraseData : LoadabelObject
        {
            public int Id;
            public int SpeachTextId;
            public int ReplayTextId;

            public override void Init(string[] data)
            {
                Id = int.Parse(data[0]);
                SpeachTextId = int.Parse(data[1]);
                ReplayTextId = int.Parse(data[2]);
            }
        }

        [Serializable]
        public class SpiritData : LoadabelObject
        {
            public int Id;
            public string Name;
            public int[] Phrases;
            public bool IsPremium;

            public override void Init(string[] data)
            {
                Id = int.Parse(data[0]);
                Name = data[1];

                var split = data[2].Split(',');
                Phrases = new int[split.Length];
                for (int i = 0; i < split.Length; i++)
                {
                    Phrases[i] = int.Parse(split[i]);
                }

                IsPremium = int.Parse(data[3]) != 0;
            }
        }
    }
}
