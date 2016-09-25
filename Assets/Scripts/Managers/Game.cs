using UnityEngine;
using System;


namespace ExtrasensoryGame
{
	public class Game : MonoBehaviour 
	{
        private static Game _instance;
        public static Game Instance { get { return _instance ?? (_instance = GameObject.FindObjectOfType<Game>()); } }

        public ProgressBar.ProgressBarBehaviour MagicPowerBar;
		public PlayerData Player = new PlayerData();
		public GameObject Client;
		public ClientGenerator clientGenerator;
		public ActiveObject Door;
		public Action EyeUsing;
		public SpiritDialogPanel SpiritDialogInstance;

        [SerializeField]
        private ResourceManager resourceManager;

        private void Awake()
        {
            this.Player.Items = resourceManager.LoadArtifactItems();
        }

        private void Start()
        {
            _instance = this;       
        }

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
