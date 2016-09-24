﻿using System;
using ExtrasensoryGame.Data;
using UnityEngine;

namespace ExtrasensoryGame.Cupboard
{
    public class CupboardPanel : MonoBehaviour
    {
        [SerializeField]
        private CupboardUIItem _prefab;

        private ItemData[] _items;
        private Action<ItemData> _callback = delegate{};

        private CupboardUIItem[] _cupboardUiItems;

        public void ShowPanel(ItemData[] items, Action<ItemData> callback)
        {
            _items = items;
            _cupboardUiItems = new CupboardUIItem[items.Length];

            for (int i = 0; i < _cupboardUiItems.Length; i++)
            {
                _cupboardUiItems[i] = Instantiate(_prefab);
                _cupboardUiItems[i].Init(_items[i], ItemClickhandler);
            }

            _callback = callback;
            gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            gameObject.SetActive(false);
        }

        private void ItemClickhandler(ItemData item)
        {
            _callback(item);
            ClosePanel();
        }
    }
}
