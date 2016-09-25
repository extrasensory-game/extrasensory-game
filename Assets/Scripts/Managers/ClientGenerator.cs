using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ExtrasensoryGame
{
	public class ClientGenerator : MonoBehaviour {

		public SpriteManager SpriteManager;

		public ClientData GetClient()
		{
			var client = new ClientData ();
            
			var a = SpriteManager.GetRandomHeat ();
			if(a!=null)
				client.CharacterSprites.Add (a);
			a = SpriteManager.GetRandomBody ();
			if(a!=null)
				client.CharacterSprites.Add (a);
			return client;
		}

	}
}
