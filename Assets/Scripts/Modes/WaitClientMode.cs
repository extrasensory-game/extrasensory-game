using UnityEngine;
using UnityEngine.UI;
using ExtrasensoryGame;

public class WaitClientMode : IMode
{
    private bool waiting = true;
    private readonly GameObject nextClientPanel;
	private Game _game;
    public WaitClientMode(GameObject nextClientPanel)
    {
        this.nextClientPanel = nextClientPanel;
    }

	public void Init(Game game)
	{
		_game = game;
        this.nextClientPanel.SetActive(true);
		_game.Door.DoorOpened += CallNextClient;
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
		this.nextClientPanel.SetActive(false);
		_game.Door.DoorOpened -= CallNextClient;
    }

    private void CallNextClient()
    {
        Debug.Log("Call next client");
        waiting = false;
    }
}