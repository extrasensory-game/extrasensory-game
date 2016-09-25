using UnityEngine;

namespace ExtrasensoryGame.Shop
{
    public class BaseShopPage : MonoBehaviour
    {
        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
