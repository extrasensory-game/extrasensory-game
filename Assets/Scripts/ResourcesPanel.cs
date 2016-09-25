using ExtrasensoryGame.Cupboard;
using ExtrasensoryGame.Shop;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame
{
    public class ResourcesPanel : MonoBehaviour
    {
        [SerializeField]
        private Text _money;
        [SerializeField]
        private Text _spirits;
        [SerializeField]
        private Text _hum;
        [SerializeField]
        private Text _quack;

        [SerializeField] private ShopPanel _shopPanel;

        private void Update()
        {
            _money.text = string.Format("{0}", Game.Instance.Player.Money);
            _spirits.text = string.Format("{0}", Game.Instance.Player.SpiritPoints);
            _hum.text = string.Format("{0}", Game.Instance.Player.HumanityPoints);
            _quack.text = string.Format("{0}", Game.Instance.Player.QuackPoints);
        }

        public void ClickMoney()
        {
            _shopPanel.Show();
        }
    }
}
