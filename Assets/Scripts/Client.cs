using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExtrasensoryGame.Data;

namespace ExtrasensoryGame
{
	public class Client {

		public List<SpriteInstance> CharacterSprites = new List<SpriteInstance>();
		public SpiritData SpiritData;
        public ClientData ClientData;

		public ClientInstance ClientInstance;
        public int confidience = 0;
		public EyeStatus EyeStatus;
		public bool IsHavingSpirit { get; set; }

	}
}
