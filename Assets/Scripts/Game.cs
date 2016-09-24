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
		// Use this for initialization
		void Start () {
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
