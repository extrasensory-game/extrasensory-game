using System;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Shop
{
    public class ShopItem : MonoBehaviour
    {
        [SerializeField]
        private Text _name;
        [SerializeField]
        private Text _price;

        private ItemData _item;
        private Action<ItemData> _callback = delegate{};

        public void Init(ItemData item, Action<ItemData> callback)
        {
            _item = item;
            _callback = callback;

            _name.text = _item.Name;
            _price.text = string.Format("{0}$", _item.Price);
        }

        public void OnClick()
        {
            _callback(_item);
        }
    }
}
