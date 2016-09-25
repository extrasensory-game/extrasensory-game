using ExtrasensoryGame;
using UnityEngine;

public class ClientMode : IMode
{
    private Game _game;
    private bool _eyeUsed = false;

    public void Init(Game game)
    {
        Debug.Log("Init ClientMode");
        _game = game;
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
    }
}