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
			
		
		

		// Update is called once per frame
		void Update () {
			MagicPowerBar.Value = Player.MagicPower;
		}
	}
}
