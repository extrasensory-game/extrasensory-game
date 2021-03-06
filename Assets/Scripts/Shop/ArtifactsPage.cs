﻿using System;
using ExtrasensoryGame.Data;
using UnityEngine;

namespace ExtrasensoryGame.Shop
{
    public class ArtifactsPage : BaseShopPage
    {
        [SerializeField]
        private ShopItem _prefab;

        private ShopItem[] _items;

        public void Init(ItemData[] loadArtifactItems, Action<ItemData>  callback)
        {
            _items = new ShopItem[loadArtifactItems.Length];

            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = Instantiate(_prefab);
                _items[i].Init(loadArtifactItems[i], callback);
                _items[i].transform.SetParent(transform);
            }
        }
    }
}
