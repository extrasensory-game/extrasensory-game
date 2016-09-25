using UnityEngine;
using System.Collections.Generic;

namespace ExtrasensoryGame
{
	public class SpriteManager : MonoBehaviour {
        [SerializeField]
		private List<SpriteInstance> heatSprites = new List<SpriteInstance> ();

        [SerializeField]
        private List<SpriteInstance> bodySprites = new List<SpriteInstance> ();

        [SerializeField]
        private List<SpriteInstance> faceSprites = new List<SpriteInstance>();

        public SpriteInstance GetRandomHeat()
        {
            return heatSprites.Count > 0 ? heatSprites [Random.Range (0, heatSprites.Count)] : null;
        }

		public SpriteInstance GetRandomBody()
		{
		    return bodySprites.Count > 0 ? bodySprites [Random.Range(0, bodySprites.Count)] : null;
		}

        public SpriteInstance GetRandomFace()
        {
            return faceSprites.Count > 0 ? faceSprites[Random.Range(0, faceSprites.Count)] : null;
        }
    }
}
