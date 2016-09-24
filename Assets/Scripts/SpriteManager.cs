using UnityEngine;
using System.Collections.Generic;

namespace ExtrasensoryGame
{
	public class SpriteManager : MonoBehaviour {

		public List<SpriteInstance> heatSprites = new List<SpriteInstance> ();
		public List<SpriteInstance> bodySprites = new List<SpriteInstance> ();

		public SpriteInstance GetRandomHeat()
		{
			if (heatSprites.Count > 0)
				return heatSprites [Random.Range (0, heatSprites.Count)];
			else
				return null;
		}

		public SpriteInstance GetRandomBody()
		{
			if (bodySprites.Count > 0)
				return bodySprites [Random.Range(0, bodySprites.Count)];
			else
				return null;
		}
	}
}
