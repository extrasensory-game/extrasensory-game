using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Assets.Scripts
{
    public class MagicSphereController : MonoBehaviour
    {
        [SerializeField]
        private List<Toggle> toggles;

        [SerializeField]
        private SpriteRenderer background;

        [SerializeField]
        private Sprite gameBackgroundSprite;

        // Update is called once per frame
        private void Update()
        {
            int counter = 0;

            foreach (var toggle in toggles)
            {
                if (toggle.isOn)
                    counter++;
            }
            if (counter == 3)
            {
                StartCoroutine(WaitAndDisable());
            }

            //if (Input.GetKey(KeyCode.Space))
            //{
            //    background.sprite = null;
            //    gameObject.SetActive(true);
            //}
        }

        private IEnumerator WaitAndDisable()
        {
            yield return new WaitForSeconds(0.1f);
            gameObject.SetActive(false);
        }
    }
}