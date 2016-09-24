using UnityEngine;
using System.Collections;
namespace ExtrasensoryGame
{
	public class Game : MonoBehaviour 
	{
		public ProgressBar.ProgressBarBehaviour MagicPowerBar;
		public Player Player = new Player();
		public GameObject Client;
		public ClientGenerator clientGenerator;
		Client clientInstance;

	    private void Start()
	    {
	        InitNewClient();
	    }


	    private void InstantiateSprite(SpriteInstance spriteInstance)
		{
			var go = (SpriteInstance)GameObject.Instantiate (spriteInstance, new Vector3 (0, 0, spriteInstance.Layer), Quaternion.identity);
			go.transform.parent = Client.transform;
		}

		public void InitNewClient()
		{
			//Destroy old client if exist P.S. shitcode))
			if (Client != null)
				Destroy (Client);
			Client = new GameObject ();

			clientInstance = clientGenerator.GetClient();
			foreach (var sprite in clientInstance.CharacterSprites) 
			{
				InstantiateSprite (sprite);
			}
		}

		// Update is called once per frame
		void Update () {
			MagicPowerBar.Value = Player.MagicPower;
		}

		public void UseEyeByClient()
		{
			if (clientInstance.ClientState.EyeStatus == EyeStatus.None) 
			{
				if (clientInstance.IsHavingSpirit)
					clientInstance.ClientState.EyeStatus = EyeStatus.WithGhost;
				else clientInstance.ClientState.EyeStatus = EyeStatus.WithoutGhost;

				Player.MagicPower -= 20;
			}
			else if (clientInstance.ClientState.EyeStatus == EyeStatus.WithGhost ||
			    clientInstance.ClientState.EyeStatus == EyeStatus.Characteristic3) {
				return;
			} else {
				clientInstance.ClientState.EyeStatus++;
				Player.MagicPower -= 10;
			}
			return;
		}
	}
}
