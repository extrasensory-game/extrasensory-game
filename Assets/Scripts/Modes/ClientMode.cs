using ExtrasensoryGame;
using UnityEngine;

public class ClientMode : IMode
{
    private Game _game;
    private readonly GameObject clientPrefab;
    private bool _eyeUsed = false;

    public Client Client;

    public ClientMode(Client client, GameObject clientPrefab)
    {
        this.Client = client;
        this.clientPrefab = clientPrefab;
    }

    public void Init(Game game)
    {
        Debug.Log("Init ClientMode");
        _game = game;
        var clientObject = GameObject.Instantiate(clientPrefab);
		Client.ClientInstance = clientObject.GetComponent<ClientInstance> ();
        foreach (var sprite in this.Client.CharacterSprites)
            InstantiateSprite(clientObject, sprite);
        _game.EyeUsing += EyeUsing;
    }

    public void Update()
    {
    }

    public bool IsFinished()
    {
        return _eyeUsed;
    }

    public void Deinit()
    {
        _game.EyeUsing -= EyeUsing;
    }

    private void EyeUsing()
    {
		_eyeUsed = true;
		_game.Player.MagicPower -= 20;
    }

    private void InstantiateSprite(GameObject clientObject, SpriteInstance spriteInstance)
    {
        var go = (SpriteInstance)GameObject.Instantiate(
            spriteInstance, new Vector3(0, 0, spriteInstance.Layer), Quaternion.identity);
        go.transform.parent = clientObject.transform;
    }
}