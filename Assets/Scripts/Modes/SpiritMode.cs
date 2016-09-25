using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

using ExtrasensoryGame.Data;
using ExtrasensoryGame.Cupboard;

public class SpiritMode : IMode
{
    private GameObject _spiritObject;
    
	private readonly Client clientData;
    private readonly Spirit spirit;
	private readonly GameObject clientPanel;
    private readonly Cupboard cupboard;
    private readonly Slider rageSlider;

    private Game _game;

    public UIManager UIManager;

	// Хранит инфу о рассположении инфы на объекте клиента(характеристики)
	private ClientInstance clientInstance;

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
		_game.SpiritDialogInstance.gameObject.SetActive(true);        
	}

	public void Init(Game game)
    {
        Debug.Log("Init SpiritMode");
        _game = game;
		_game.Player.CurrentClient = this.clientData;  
		_game.Door.Action += InitDialog;
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
        return false;
    }

    public void Deinit()
	{
		_game.Player.CurrentClient = null;
        if (_spiritObject != null)
            GameObject.Destroy(_spiritObject);

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