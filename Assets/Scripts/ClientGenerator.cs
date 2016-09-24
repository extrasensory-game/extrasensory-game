using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace ExtrasensoryGame
{
	public class ClientGenerator : MonoBehaviour {

		public SpriteManager SpriteManager;
		public Client TestClient;
		// Use this for initialization
		void Start () {
		
		}

		// Update is called once per frame
		void Update () {
		
		}

		public Client GetClient()
		{
			TestClient.CharacterSprites = new List<SpriteInstance> ();
			var a = SpriteManager.GetRandomHeat ();
			if(a!=null)
				TestClient.CharacterSprites.Add (a);
			return TestClient;
		}

	}
}
