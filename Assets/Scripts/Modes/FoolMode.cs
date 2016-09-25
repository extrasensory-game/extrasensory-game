using ExtrasensoryGame;
using UnityEngine;

public class FoolMode : IMode
{
	private readonly Client client;
	private Game _game;

    private readonly ClickableCollider _globeCollider;
    private readonly GameObject _astrologyPanel;

    public FoolMode(Client client, ClickableCollider globeCollider, GameObject astrologyPanel)
    {
        this.client = client;
        this._globeCollider = globeCollider;
        this._astrologyPanel = astrologyPanel;
    }

    public void Init(Game game)
	{
		_game = game;
		Debug.Log("Init FoolMode");
		_game.EyeUsing += UseEye;
        _globeCollider.OnClick += ShowGlobusGame;
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
        _globeCollider.OnClick -= ShowGlobusGame;
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