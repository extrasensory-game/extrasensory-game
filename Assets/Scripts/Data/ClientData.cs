using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExtrasensoryGame.Data;

namespace ExtrasensoryGame
{
	public class ClientData {

		public List<SpriteInstance> CharacterSprites = new List<SpriteInstance>();
		public SpiritData SpiritData;

		public int confidience = 0;
		public EyeStatus EyeStatus;
		public bool IsHavingSpirit { get; set; }

	}
}
