using UnityEngine;
using System.Collections;
namespace ExtrasensoryGame
{
	public class Game : MonoBehaviour 
	{
		public SpriteRenderer PlayerSprite;
		public ClientGenerator clientGenerator;
		Client client;
		// Use this for initialization
		void Start () {
			client = clientGenerator.GetClient();
			PlayerSprite.sprite = client.Sprite;
		}
		
		// Update is called once per frame
		void Update () {

		}

		public int UseEyeByClient()
		{
			if (client.ClientState.EyeStatus == EyeStatus.WithGhost ||
			    client.ClientState.EyeStatus == EyeStatus.Characteristic3) {
				return 0;
			} else {
				client.ClientState.EyeStatus++;
			}
			return 0;
		}
	}
}
