using System.Linq;
using ExtrasensoryGame;
using UnityEngine;
using UnityEngine.UI;

public class FoolMode : IMode
{
	private readonly Client client;
	private Game _game;
    private GameObject _astrologyPanel;
    private GameObject _foolTablePanel;
    private Button _globusButton;

    public FoolMode(Client client, GameObject foolTablePanel, GameObject astrologyPanel)
    {
        this.client = client;
        this._astrologyPanel = astrologyPanel;
        _foolTablePanel = foolTablePanel;
    }

    public void Init(Game game)
	{
		_game = game;
		Debug.Log("Init FoolMode");
		_game.EyeUsing += UseEye;
        this._foolTablePanel.SetActive(true);
	    var buttons = this._foolTablePanel.GetComponentsInChildren<Button>();
	    _globusButton = buttons.First(button => button.gameObject.name == "GlobusButton");
        _globusButton.onClick.AddListener(ShowGlobusGame);
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
        this._astrologyPanel.SetActive(false);
        _globusButton.onClick.RemoveListener(ShowGlobusGame);
    }

    private void UseEye()
	{
		switch (client.EyeStatus) 
		{
		case EyeStatus.None:
			client.ClientInstance.Characteristic1.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			client.EyeStatus = EyeStatus.Characteristic1;
			break;
		case EyeStatus.Characteristic1:
			client.ClientInstance.Characteristic2.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			client.EyeStatus = EyeStatus.Characteristic2;
			break;
		case EyeStatus.Characteristic2:
			client.ClientInstance.Characteristic3.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			client.EyeStatus = EyeStatus.Characteristic3;
			break;
		default:
			break;

		}
	}

    public void ShowGlobusGame()
    {
        _astrologyPanel.SetActive(true);
    }
}