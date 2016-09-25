using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Shop
{
    public class PromoCodePage : BaseShopPage
    {
        [SerializeField]
        private InputField _input;

        private const string PronoCod = "HAKATON2016";
        private bool isUsedCod = false;

        public void OnClick()
        {
            Debug.Log(_input.text);
            if (string.Equals(PronoCod, _input.text) && !isUsedCod)
            {
                isUsedCod = true;
                Game.Instance.Player.Money += 1000;
            } 
        }
    }
}
