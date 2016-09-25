using UnityEngine;
using System.Collections;
using System;


namespace ExtrasensoryGame
{
	public class Game : MonoBehaviour 
	{
		public ProgressBar.ProgressBarBehaviour MagicPowerBar;
		public PlayerData Player = new PlayerData();
		public GameObject Client;
		public ClientGenerator clientGenerator;
		public ActiveObject Door;
		public Action EyeUsing;
		public SpiritDialogPanel SpiritDialogInstance;

		public void UseEye()
		{
			if (EyeUsing != null)
				EyeUsing ();
		}

		// Update is called once per frame
		void Update () {
			MagicPowerBar.Value = Player.MagicPower;
		}
	}
}
