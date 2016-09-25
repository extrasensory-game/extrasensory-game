using System;
using System.Collections;
using ExtrasensoryGame;
using UnityEngine;

public class ClientMode : IMode
{
    private Game _game;
    private readonly GameObject _clientPrefab;
    private readonly GameObject _openingDoor;

    private DateTime _initTime;
    private bool _clientIsHere = false;
    private bool _eyeUsed = false;

    public Client Client;

    public ClientMode(Client client, GameObject clientPrefab, GameObject openingDoor)
    {
        this.Client = client;
        this._clientPrefab = clientPrefab;
        this._openingDoor = openingDoor;
    }

    public void Init(Game game)
    {
        Debug.Log("Init ClientMode");
        _game = game;
        _initTime = DateTime.Now;
        _openingDoor.SetActive(true);
    }

    public void Update()
    {
        if (!_clientIsHere && DateTime.Now - _initTime > TimeSpan.FromSeconds(0.5))
        {
            this._openingDoor.SetActive(false);
            var clientObject = GameObject.Instantiate(_clientPrefab);
            Client.ClientInstance = clientObject.GetComponent<ClientInstance>();
            foreach (var sprite in this.Client.CharacterSprites)
                InstantiateSprite(clientObject, sprite);
            _game.EyeUsing += EyeUsing;
            _clientIsHere = true;
        }
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
		_game.Player.MagicPower -= 10;
    }

    private void InstantiateSprite(GameObject clientObject, SpriteInstance spriteInstance)
    {
        var go = GameObject.Instantiate(spriteInstance);
        go.transform.parent = clientObject.transform;
		go.transform.position = new Vector3 (go.transform.position.x, go.transform.position.y, spriteInstance.Layer);
    }
}