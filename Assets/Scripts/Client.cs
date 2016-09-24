using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ExtrasensoryGame.Data;

namespace ExtrasensoryGame
{
	public class Client {

		public List<SpriteInstance> CharacterSprites = new List<SpriteInstance>();
		public List<SpriteInstance> SpiritSprites = new List<SpriteInstance>();
		public ClientState ClientState = new ClientState();
		public SpiritData SpiritData;

		public bool IsHavingSpirit { get; set; }

	}
}
