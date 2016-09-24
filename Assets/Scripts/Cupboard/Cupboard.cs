using ExtrasensoryGame.Data;
using UnityEngine;

namespace ExtrasensoryGame.Cupboard
{
    public class Cupboard : MonoBehaviour
    {
        [SerializeField]
        private ResourceManager _resourceManager;

        private ItemData[] _items;

        private void Start()
        {
            _items = _resourceManager.GetItems();
            Debug.Log(_items.Length);
        }

        public void OnMouseUpAsButton()
        {
            Debug.Log("Open cupboard");

        }
    }
}
