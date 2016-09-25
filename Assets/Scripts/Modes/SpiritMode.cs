using System;
using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

using ExtrasensoryGame.Data;
using ExtrasensoryGame.Cupboard;
using ExtrasensoryGame.Data.SpiritDialogs;

public class SpiritMode : IMode
{
    private bool is_finished = false;
    private GameObject _spiritObject;
    
	private readonly Client clientData;
    private readonly Spirit spirit;
	private readonly GameObject clientPanel;
    private readonly Cupboard cupboard;
    private readonly Slider rageSlider;
    private readonly GameObject extrasensoryEffect;

    private Game _game;

    public UIManager UIManager;

	// Хранит инфу о рассположении инфы на объекте клиента(характеристики)
	private SpiritDialog dialog;
    private ItemData _selectedItem;

	public SpiritMode(Client client, Spirit spirit, GameObject clientPanel, GameObject cupboard, GameObject rageSlider,
        GameObject extrasensoryEffect)
    {
        this.clientData = client;
		this.spirit = spirit;
		this.clientPanel = clientPanel;
        this.extrasensoryEffect = extrasensoryEffect;
        this.cupboard = cupboard.GetComponent<Cupboard>();
        this.rageSlider = rageSlider.GetComponent<Slider>();
    }

    public void SpiritClicked()
    {
        if (this._selectedItem != null)
        {
            ApplyItem();
        }
        else
        {
            InitDialog();
        }
    }

	public void InitDialog()
	{
		dialog = spirit.GetNextDialog ();
		if (dialog == null) {
			is_finished = true;
			return;
        }

        this.clientData.ClientInstance.Action -= SpiritClicked;

        _game.SpiritDialogInstance.gameObject.SetActive(true);
		_game.SpiritDialogInstance.OnAnswerAction += CheckAnswer;
		_game.SpiritDialogInstance.Answer1Text.text = dialog.Pharases [0].Speach;
		_game.SpiritDialogInstance.Answer2Text.text = dialog.Pharases [1].Speach;
		_game.SpiritDialogInstance.Answer3Text.text = dialog.Pharases [2].Speach;
		_game.SpiritDialogInstance.QuestionText.text = dialog.Text;
	}

	private void CheckAnswer(int i)
	{
		_game.SpiritDialogInstance.OnAnswerAction -= CheckAnswer;
		_game.SpiritDialogInstance.gameObject.SetActive(false);
		spirit.SelectPhrase (dialog.Pharases [i-1]);
        this.clientData.ClientInstance.Action += SpiritClicked;
    }

	public void Init(Game game)
    {
        Debug.Log("Init SpiritMode");
        _game = game;
		_game.Player.CurrentClient = this.clientData;  
		this.clientData.ClientInstance.Action += SpiritClicked;
		ShowSpirit ();
        extrasensoryEffect.SetActive(true);
        cupboard.gameObject.SetActive(true);
        this.rageSlider.gameObject.SetActive(true);

        this.spirit.OnRageChanged += RageChanged;
        this.cupboard.ItemClicked += CupboardItemClicked;
        this.spirit.OnStateChanged += SpiritWasCatched;

        this.RageChanged(0f);
        this.rageSlider.enabled = false;
    }

    private void ApplyItem()
    {
        this.spirit.ApplyItem(this._selectedItem);
        this._selectedItem = null;
    }

    private void RageChanged(float rageValue)
    {
        this.rageSlider.value = (rageValue + 100f) / 200f;
    }

    public void Update()
    {
    }

    public bool IsFinished()
    {
		return is_finished;
    }

    public void Deinit()
	{
		if (_spiritObject != null)
			GameObject.Destroy(_spiritObject);
		if (this.clientData.ClientInstance != null)
			GameObject.Destroy(this.clientData.ClientInstance.gameObject);

		this.clientData.ClientInstance.Action -= SpiritClicked;
        extrasensoryEffect.SetActive(false);
        cupboard.gameObject.SetActive(false);
        rageSlider.gameObject.SetActive(false);

        spirit.OnRageChanged -= RageChanged;
        this.cupboard.ItemClicked -= CupboardItemClicked;
        this.spirit.OnStateChanged -= SpiritWasCatched;
    }

    private void SpiritWasCatched(SpiritState spiritState)
    {
        // Spirit was cached!
        var x = 10;
    }

    private void CupboardItemClicked(ItemData itemData)
    {
        this._selectedItem = itemData;
    }

    public void GhostClicked()
    {
        if (this._selectedItem != null)
        {
            this.spirit.ApplyItem(this._selectedItem);
        }
    }

    private void UseEye()
	{
	}

    private void ShowSpirit()
    {
        _spiritObject = GameObject.Instantiate(this.spirit.Prefab);
    }
}