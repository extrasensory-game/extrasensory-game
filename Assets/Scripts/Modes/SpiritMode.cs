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

    private Game _game;

    public UIManager UIManager;

	// Хранит инфу о рассположении инфы на объекте клиента(характеристики)
	private SpiritDialog dialog;

	public SpiritMode(Client client, Spirit spirit, GameObject clientPanel, GameObject cupboard, GameObject rageSlider)
    {
        this.clientData = client;
		this.spirit = spirit;
		this.clientPanel = clientPanel;
        this.cupboard = cupboard.GetComponent<Cupboard>();
        this.rageSlider = rageSlider.GetComponent<Slider>();
    }

	public void InitDialog()
	{
		dialog = spirit.GetNextDialog ();
		if (dialog == null) {
			is_finished = true;
			return;
		}
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
	}

	public void Init(Game game)
    {
        Debug.Log("Init SpiritMode");
        _game = game;
		_game.Player.CurrentClient = this.clientData;  
		this.clientData.ClientInstance.Action += InitDialog;
		ShowSpirit ();
        cupboard.gameObject.SetActive(true);
        this.rageSlider.gameObject.SetActive(true);
        this.spirit.RageChanged += RageChanged;        
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

		this.clientData.ClientInstance.Action -= InitDialog;
        cupboard.gameObject.SetActive(false);
        rageSlider.gameObject.SetActive(false);
        spirit.RageChanged -= RageChanged;
    }

	private void UseEye()
	{
	}

    private void ShowSpirit()
    {
        _spiritObject = GameObject.Instantiate(this.spirit.Prefab);
    }

    public void UseItem(ItemData item)
    {
    }
}