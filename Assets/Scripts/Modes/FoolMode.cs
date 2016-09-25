using ExtrasensoryGame;
using UnityEngine;

public class FoolMode : IMode
{
    private readonly Client client;

    public FoolMode(Client client)
    {
        this.client = client;
    }

    public void Init(Game game)
    {
        Debug.Log("Init FoolMode");
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
    }
}