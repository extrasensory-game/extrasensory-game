using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ExtrasensoryGame
{
	public class Client {

		public List<SpriteInstance> CharacterSprites = new List<SpriteInstance>();
		public List<SpriteInstance> SpiritSprites = new List<SpriteInstance>();
		public ClientState ClientState = new ClientState();
		public SpiritState SpiritState = new SpiritState();

		public bool IsHavingSpirit { get; set; }
		// Use this for initialization
		void Start () 
		{
		
		}
		
		// Update is called once per frame
		void Update () 
		{
		
		}
	}
}
