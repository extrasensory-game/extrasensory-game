using System.Collections;
using System.Collections.Generic;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Assets.Scripts
{
    public class MagicSphereController : MonoBehaviour
    {
        [SerializeField]
        private List<Toggle> toggles;

        [SerializeField]
        private Text receivedPoints;

        [SerializeField]
        private ResourceManager resourceManager;

        [SerializeField]
        private SpriteRenderer background;

        [SerializeField]
        private Sprite gameBackgroundSprite;

        private Sprite mainBackgroundSprite;

        private HoroscopePhrase[] phrases;
        private int sum = 0;

        [SerializeField]
        private GameObject table;

        private GameObject player;

        public static bool ClientGoAway = false;

        // Update is called once per frame
        private void Start()
        {
            mainBackgroundSprite = background.sprite;
            background.sprite = gameBackgroundSprite;
            table.SetActive(false);
            player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(false);
            ClientGoAway = false;

            phrases = resourceManager.GetRandomHoroscopePhrases();
            for (int i = 0; i < toggles.Count; i++)
                toggles[i].GetComponentInChildren<Text>().text = phrases[i].Text;

            foreach (Toggle toggle in toggles)
            {
                toggle.gameObject.SetActive(true);
            }

        }

        private void Update()
        {
            sum = 0;
            int counter = 0;
            for (int i = 0; i < toggles.Count; i++)
            {
                if (toggles[i].isOn)
                {
                    counter++;
                    sum += (int)phrases[i].RageModifierValue;
                }
            }

            if (counter == 3)
            {
                StartCoroutine(WaitAndDisable());
                
            }
        }

        private IEnumerator WaitAndDisable()
        {
            yield return new WaitForSeconds(0.1f);
            if (sum <= 0)
            {
                receivedPoints.text = "Вы - шарлатан! +1 очко шарлатана";
                Game.Instance.Player.QuackPoints++;
            }
            else
            {
                receivedPoints.text = "Спасибо! Вот вам за хороший гороскоп: " + sum + "$";
                Game.Instance.Player.Money += sum;
            }
            receivedPoints.gameObject.SetActive(true);

            
            background.sprite = mainBackgroundSprite;
            
            table.SetActive(true);

            //yield return new WaitForSeconds(2f);
            StartCoroutine(WaitAndDisable2());
        }

        private IEnumerator WaitAndDisable2()
        {
            foreach (Toggle toggle in toggles)
            {
                toggle.gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(2f);

            receivedPoints.text = "";

            player.SetActive(true);

            ClientGoAway = true;
            GameObject.Destroy(player);
        }
    }
}