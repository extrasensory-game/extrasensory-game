using System;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Cupboard
{
    public class CupboardUIItem : MonoBehaviour
    {
        private Text _itemName;

        private Action<ItemData> _clickHandler = delegate {};
        private ItemData _itemData;

        public void Init(ItemData itemData, Action<ItemData> clickHandler)
        {
            _itemName.text = itemData.Name;
            _itemData = itemData;
            _clickHandler = clickHandler;
        }

        public void Click()
        {
            _clickHandler(_itemData);
        }
    }
}
