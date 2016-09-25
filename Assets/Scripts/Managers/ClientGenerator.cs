using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ExtrasensoryGame
{
	public class ClientGenerator : MonoBehaviour {

		public SpriteManager SpriteManager;

		public Client GetClient()
		{
			var client = new Client ();
            
			var a = SpriteManager.GetRandomHeat ();
			if(a!=null)
				client.CharacterSprites.Add (a);
			a = SpriteManager.GetRandomBody ();
			if(a!=null)
				client.CharacterSprites.Add (a);
            a = SpriteManager.GetRandomFace();
            if (a != null)
                client.CharacterSprites.Add(a);
            return client;
		}

	}
}
