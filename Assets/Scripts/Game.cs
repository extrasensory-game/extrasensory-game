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
		public Door Door;
		// Use this for initialization
		void Start () {
		}
			
		public void UseEye()
		{
			if (Player.CurrentClient == null)
				return;
			Debug.Log (Player.CurrentClient.EyeStatus);
			if (Player.CurrentClient.EyeStatus == EyeStatus.None) {
				Player.MagicPower -= 20;
				Player.CurrentClient.EyeStatus++;
			} else if (Player.CurrentClient.EyeStatus != EyeStatus.WithGhost &&
			        Player.CurrentClient.EyeStatus != EyeStatus.Characteristic3) {
				Player.MagicPower -= 10;
				Player.CurrentClient.EyeStatus++;
			}
		}
		// Update is called once per frame
		void Update () {
			MagicPowerBar.Value = Player.MagicPower;
		}
	}
}
