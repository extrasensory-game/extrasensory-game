using ExtrasensoryGame;
using ExtrasensoryGame.Data;
using UnityEngine;

public class SpiritMode : IMode
{
    private GameObject _spiritObject;

    private int _framesCount = 0;
    private Client client;
    private SpiritData spiritData;
    private GameObject clientObject;

    public void Init()
    {
        _spiritObject = GameObject.Instantiate(this.spiritData.Prefab);
        this.clientObject = new GameObject();

        foreach (var sprite in client.CharacterSprites)
        {
            InstantiateSprite(sprite);
        }
    }

    public void Update()
    {
    }

    private void InstantiateSprite(SpriteInstance spriteInstance)
    {
        var go = (SpriteInstance)GameObject.Instantiate(spriteInstance, new Vector3(0, 0, spriteInstance.Layer), Quaternion.identity);
        go.transform.parent = this.clientObject.transform;
    }

    public SpiritMode(Client client, SpiritData spiritData)
    {
        this.client = client;
        this.spiritData = spiritData;
    }

    public bool IsFinished()
    {
        ++_framesCount;
        return _framesCount > 200;
    }

    public void Deinit()
    {
    }
}