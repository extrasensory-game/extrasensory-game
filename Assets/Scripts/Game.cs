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
		public Door Door;
		// Use this for initialization
		void Start () {
		}
			
		public void UseEye()
		{
			if (Player.CurrentClient == null)
				return;
			switch (Player.CurrentClient.EyeStatus) 
			{
			case EyeStatus.None:
				Player.MagicPower -= 20;
				if (Player.CurrentClient.IsHavingSpirit)
					Player.CurrentClient.EyeStatus = EyeStatus.WithGhost;
				else
					Player.CurrentClient.EyeStatus = EyeStatus.WithoutGhost;
				break;
			case EyeStatus.WithoutGhost:
			case EyeStatus.Characteristic1:
			case EyeStatus.Characteristic2:
				Player.MagicPower -= 10;
				Player.CurrentClient.EyeStatus++;
				break;
			default:
				break;
				
			}
		}
		// Update is called once per frame
		void Update () {
			MagicPowerBar.Value = Player.MagicPower;
		}
	}
}
