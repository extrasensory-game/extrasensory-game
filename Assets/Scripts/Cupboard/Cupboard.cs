using System;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ExtrasensoryGame.Cupboard
{
    public class Cupboard : MonoBehaviour
	{
		public event Action<ItemData> ItemClicked;

        [SerializeField]
        private CupboardPanel _cupboardPanel;

        private SpiritMode SpiritMode { get { return GameObject.FindObjectOfType<ModeManager>().SpiritMode; } }

        public void OnMouseUpAsButton()
        {
			
            if(!EventSystem.current.IsPointerOverGameObject())
            {
				
                _cupboardPanel.ShowPanel(Game.Instance.Player.Items, data =>
                {
                    if (ItemClicked != null)
                        ItemClicked(data);

                    Debug.Log(string.Format("{0}, {1}", data.Name, data.Id));
                });
            }            
        }
    }
}
