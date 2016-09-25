using UnityEngine;
using System.Collections;
using System;
using System.Linq;


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
            if (GameObject.FindObjectsOfType<Game>().Count() > 1)
                GameObject.Destroy(this);

            this.Player.Items = resourceManager.LoadArtifactItems();
        }

        private void Start()
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(gameObject);            
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
