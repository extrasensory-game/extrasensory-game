using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ExtrasensoryGame;

public class EndMode : IMode
{
	private readonly GameObject restartPanel;
	private Game _game;

    public EndMode(GameObject restartPanel)
    {
        this.restartPanel = restartPanel;
    }
    
	public void Init(Game game)
	{
		_game = game;
        this.restartPanel.SetActive(true);
        this.restartPanel.GetComponentInChildren<Button>().onClick.AddListener(Restart);
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
        throw new NotImplementedException();
    }

    private void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Intro");
    }
}