using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;
using UnityEngine.UI;

public class SpiritMode : IMode
{
    private GameObject _spiritObject;

    private int _framesCount = 0;
    private Client client;
    private SpiritData spiritData;
    private GameObject clientObject;
	private readonly GameObject clientPanel;
	private Game _game;

    public SpiritMode(Client client, SpiritData spiritData, GameObject clientPanel)
    {
        this.client = client;
        this.spiritData = spiritData;
        this.clientPanel = clientPanel;
    }

	public void Init(Game game)
	{
		_game = game;
        this.clientObject = new GameObject();

        foreach (var sprite in client.CharacterSprites)
        {
            InstantiateSprite(sprite);
        }

		_game.Player.CurrentClient = this.client;
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