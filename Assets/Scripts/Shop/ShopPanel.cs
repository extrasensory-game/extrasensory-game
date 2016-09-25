using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

namespace ExtrasensoryGame.Shop
{
    public class ShopPanel : MonoBehaviour
    {
        [SerializeField]
        private ResourceManager _resourceManager;

        [SerializeField] private ArtifactsPage _artifactsPage;
        [SerializeField] private MedCheatsPage _medCheatsPage;
        [SerializeField] private UpgratesPage _upgratesPage;
        [SerializeField] private PromoCodePage _promoCodePage;

        [SerializeField] private Button _artifactButton;
        [SerializeField] private Button _medCheatButton;
        [SerializeField] private Button _upgrateButton;
        [SerializeField] private Button _promoButton;

        private void Start()
        {
            _artifactsPage.Init(_resourceManager.LoadArtifactItems(), ClickHandler);
            _medCheatsPage.Init(_resourceManager.LoadMedCheatsItems(), ClickHandler);
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ShowPage(0);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void ShowPage(int pageId)
        {
            switch (pageId)
            {
                case 0:
                    SwitchPage(_artifactsPage);
                    break;
                case 1:
                    SwitchPage(_medCheatsPage);
                    break;
                case 2:
                    SwitchPage(_upgratesPage);
                    break;
                case 3:
                    SwitchPage(_promoCodePage);
                    break;
            }
        }


        private void SwitchPage(BaseShopPage page)
        {
            _artifactButton.interactable = _artifactsPage != page;
            _medCheatButton .interactable = _medCheatsPage != page;
            _upgrateButton.interactable = _upgratesPage != page;
            _promoButton.interactable = _promoCodePage != page;

            if(_artifactsPage == page)
                _artifactsPage.Show();
            else
                _artifactsPage.Close();

            if(_medCheatsPage == page)
                _medCheatsPage.Show();
            else
                _medCheatsPage.Close();

            if(_upgratesPage == page)
                _upgratesPage.Show();
            else
                _upgratesPage.Close();

            if(_promoCodePage == page)
                _promoCodePage.Show();
            else
                _promoCodePage.Close();
        }

        public void ClickHandler(ItemData item)
        {
            if (Game.Instance.Player.Money >= item.Price)
            {
                Game.Instance.Player.Money -= item.Price;
                Game.Instance.Player.AddItem(item);
            }
        }
    }
}
