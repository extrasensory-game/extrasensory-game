using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame
{
    public class UIManager : MonoBehaviour
    {
        public GameObject RestartPanel;
        public GameObject NextClientPanel;
        public GameObject ClientPanel;
        public GameObject RageSlider;
        public GameObject Cupboard;

        private Slider rageSlider;

        private void Start()
        {
            rageSlider = RageSlider.GetComponent<Slider>();
        }

        public void SetRageSliderVisible(bool isVisible)
        {
            this.RageSlider.SetActive(isVisible);
        }

        public void SetRageSliderValue(float valuePercent)
        {
            rageSlider.value = valuePercent;
        }
    }
}