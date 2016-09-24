using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace ExtrasensoryGame.Data
{
    public static class DataParser
    {
        private const string SpeachFile = "Speach.csv";
        private const string ReplaysFile = "Replays.csv";
        private const string SpiritPhrasesFile = "SpiritPhrases.csv";
        private const string SpiritFile = "Spirit.csv";


        public static SpiritData[] LoadSpiritsData()
        {
            return (SpiritData[]) LoadTexts(SpiritFile, () => new SpiritData());
        }

        public static PhraseData[] LoadPhrases()
        {
            return (PhraseData[]) LoadTexts(SpiritPhrasesFile, () => new PhraseData());
        }

        public static TextData[] LoadSpeachTexts()
        {
            return (TextData[]) LoadTexts(SpeachFile, () => new TextData());
        }
        public static TextData[] LoadReplayTexts()
        {
            return (TextData[]) LoadTexts(ReplaysFile, () => new TextData());
        }

        private static LoadabelObject[] LoadTexts(string fileName, Func<LoadabelObject> getObjetInstance)
        {
            var text = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            List<LoadabelObject> resultList = new List<LoadabelObject>();
            StringReader reader = new StringReader(text.text);
//            using(StringReader reader = new StringReader(text.text))
            {
                string line = reader.ReadLine();
                while(!string.IsNullOrEmpty(line))
                {
                    var items = line.Split(';');
                    if(items.Length > 1 && items[0] != "id")
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
                IsPremium = bool.Parse(data[3]);
            }
        }
    }
}
