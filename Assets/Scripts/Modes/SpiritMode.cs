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
		_game.EyeUsing += UseEye;
		_game.Player.CurrentClient = this.clientData;
		_game.Door.DoorOpened += InitDialog;
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
		if (clientData == null)
			return;
		switch (clientData.EyeStatus) 
		{
		case EyeStatus.None:
			_game.Player.MagicPower -= 20;
			if (clientData.IsHavingSpirit)
				clientData.EyeStatus = EyeStatus.WithGhost;
			else
				clientData.EyeStatus = EyeStatus.WithoutGhost;
			break;
		case EyeStatus.WithoutGhost:
			clientInstance.Characteristic1.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		case EyeStatus.Characteristic1:
			clientInstance.Characteristic2.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		case EyeStatus.Characteristic2:
			clientInstance.Characteristic3.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		default:
			break;

		}
	}

    private void ShowSpirit()
    {
        _spiritObject = GameObject.Instantiate(this.spirit.Prefab);
    }
}