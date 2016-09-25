using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

public class SpiritMode : IMode
{
    private GameObject _spiritObject;
    
	private readonly Client clientData;
    private readonly Spirit spirit;
	private readonly GameObject clientPanel;
	private Game _game;

	// Хранит инфу о рассположении инфы на объекте клиента(характеристики)
	private ClientInstance clientInstance;

	public SpiritMode(Client client, Spirit spirit, GameObject clientPanel)
    {
        this.clientData = client;
		this.spirit = spirit;
		this.clientPanel = clientPanel;
    }

	public void InitDialog()
	{
		_game.SpiritDialogInstance.gameObject.SetActive (true);
	}

	public void Init(Game game)
    {
        Debug.Log("Init SpiritMode");
        _game = game;
		_game.Player.CurrentClient = this.clientData;
		_game.Door.DoorOpened += InitDialog;
		ShowSpirit ();
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
    }

	private void UseEye()
	{
	}

    private void ShowSpirit()
    {
        _spiritObject = GameObject.Instantiate(this.spirit.Prefab);
    }
}