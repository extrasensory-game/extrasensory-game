using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

public class SpiritMode : IMode
{
    private GameObject _spiritObject;

    private int _framesCount = 0;
	private Client clientData;
    private SpiritData spiritData;
	private readonly GameObject clientPanel;
	private Game _game;

	//Хранит инфу о рассположении инфы на объекте клиента(характеристики)
	private ClientInstance clientInstantiate;
	private GameObject clientObject;
	private GameObject clientPrefab;

	public SpiritMode(Client client, SpiritData spiritData, GameObject clientPanel, GameObject clientPrefab)
    {
        this.clientData = client;
		this.spiritData = spiritData;
		this.clientPanel = clientPanel;
		this.clientPrefab = clientPrefab;
    }

	public void Init(Game game)
	{
		_game = game;
		this.clientObject = GameObject.Instantiate (clientPrefab);
		clientInstantiate = this.clientObject.GetComponent<ClientInstance> ();
        foreach (var sprite in clientData.CharacterSprites)
        {
            InstantiateSprite(sprite);
        }
		_game.EyeUsing += UseEye;
		_game.Player.CurrentClient = this.clientData;
    }

    public void Update()
    {
    }

    public bool IsFinished()
    {
        // ++_framesCount;
        return _framesCount > 200;
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
			clientInstantiate.Characteristic1.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		case EyeStatus.Characteristic1:
			clientInstantiate.Characteristic2.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		case EyeStatus.Characteristic2:
			clientInstantiate.Characteristic3.gameObject.SetActive (true);
			_game.Player.MagicPower -= 10;
			clientData.EyeStatus++;
			break;
		default:
			break;

		}
	}

    private void InstantiateSprite(SpriteInstance spriteInstance)
    {
        var go = (SpriteInstance)GameObject.Instantiate(spriteInstance, new Vector3(0, 0, spriteInstance.Layer), Quaternion.identity);
        go.transform.parent = this.clientObject.transform;
    }

    private void ShowSpirit()
    {
        _spiritObject = GameObject.Instantiate(this.spiritData.Prefab);
    }
}