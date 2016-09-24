﻿using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ExtrasensoryGame.Cupboard
{
    public class Cupboard : MonoBehaviour
    {
        [SerializeField]
        private ResourceManager _resourceManager;

        [SerializeField]
        private CupboardPanel _cupboardPanel;

        private ItemData[] _items;

        private void Start()
        {
            _items = _resourceManager.GetItems();
        }

        public void OnMouseUpAsButton()
        {
            if(!EventSystem.current.IsPointerOverGameObject())
            {
                _cupboardPanel.ShowPanel(_items, data =>
                {
                    Debug.Log(string.Format("{0}, {1}", data.Name, data.Id));
                });
            }
        }
    }
}
