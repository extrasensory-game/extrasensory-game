using UnityEngine;
using System.Collections;
namespace ExtrasensoryGame
{
	public class Game : MonoBehaviour 
	{
		public GameObject Client;
		public SpriteRenderer PlayerSprite;
		public ClientGenerator clientGenerator;
		Client clientInstance;
		// Use this for initialization
		void Start () {
			InitNewClient ();
		}
		private void InstantiateSprite(SpriteInstance spriteInstance)
		{
			var go = (SpriteInstance)GameObject.Instantiate (spriteInstance, new Vector3 (0, 0, spriteInstance.Layer), Quaternion.identity);
			go.transform.parent = Client.transform;
		}

		public void InitNewClient()
		{
			clientInstance = clientGenerator.GetClient();
			foreach (var sprite in clientInstance.CharacterSprites) 
			{
				InstantiateSprite (sprite);
			}
		}

		// Update is called once per frame
		void Update () {

		}

		public void UseEyeByClient()
		{
			if (clientInstance.ClientState.EyeStatus == EyeStatus.WithGhost ||
			    clientInstance.ClientState.EyeStatus == EyeStatus.Characteristic3) {
				return;
			} else {
				clientInstance.ClientState.EyeStatus++;
			}
			return;
		}
	}
}
