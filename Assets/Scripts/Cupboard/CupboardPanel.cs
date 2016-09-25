using System;
using System.Collections.Generic;
using ExtrasensoryGame.Data;
using UnityEngine;

namespace ExtrasensoryGame.Cupboard
{
    public class CupboardPanel : MonoBehaviour
    {
        [SerializeField] private CupboardUIItem _prefab;

        [SerializeField] private RectTransform _container;

        private ItemData[] _items;
        private Action<ItemData> _callback = delegate{};

        private CupboardUIItem[] _cupboardUiItems;
        private Queue<CupboardUIItem> _queue = new Queue<CupboardUIItem>();

        public void ShowPanel(ItemData[] items, Action<ItemData> callback)
        {
            _items = items;
            _cupboardUiItems = new CupboardUIItem[items.Length];

            for (int i = 0; i < _cupboardUiItems.Length; i++)
            {
                _cupboardUiItems[i] = _queue.Count > 0 ? _queue.Dequeue() : Instantiate(_prefab);
                _cupboardUiItems[i].gameObject.SetActive(true);

                _cupboardUiItems[i].Init(_items[i], ItemClickhandler);
                var rectTransform = _cupboardUiItems[i].GetComponent<RectTransform>();
                rectTransform.SetParent(_container);
            }

            _callback = callback;
            gameObject.SetActive(true);
        }

        public void ClosePanel()
        {
            foreach (CupboardUIItem t in _cupboardUiItems)
            {
                t.gameObject.SetActive(true);
                _queue.Enqueue(t);
            }
            _cupboardUiItems = null;

            gameObject.SetActive(false);
        }

        private void ItemClickhandler(ItemData item)
        {
            _callback(item);
            ClosePanel();
        }
    }
}
