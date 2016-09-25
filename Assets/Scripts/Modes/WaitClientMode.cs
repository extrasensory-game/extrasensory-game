using UnityEngine;
using ExtrasensoryGame;

public class WaitClientMode : IMode
{
    private bool waiting = true;
	private Game _game;

	public void Init(Game game)
	{
		_game = game;
		_game.Door.Action += CallNextClient;
    }

    public void Update()
    {
    }

    public bool IsFinished()
    {
        return !waiting;
    }

    public void Deinit()
    {
		_game.Door.Action -= CallNextClient;
    }

    private void CallNextClient()
    {
        Debug.Log("Call next client");
        waiting = false;
    }
}