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
        private ResourceManager resourceManager;

        [SerializeField]
        private SpriteRenderer background;

        [SerializeField]
        private Sprite gameBackgroundSprite;

        private Sprite mainBackgroundSprite;

        private HoroscopePhrase[] phrases;
        private float sum = 0;

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
                    sum += phrases[i].RageModifierValue;
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
            Debug.Log("Сумма: " + sum);
            gameObject.SetActive(false);
            background.sprite = mainBackgroundSprite;
            player.SetActive(true);
            table.SetActive(true);
            // ыва

            ClientGoAway = true;
            GameObject.Destroy(player);
        }
    }
}