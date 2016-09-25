using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using ExtrasensoryGame;

public class EndMode : IMode
{
	private readonly GameObject restartPanel;
    private readonly GameObject diabloPrefab;
    private Game _game;

    public EndMode(GameObject restartPanel, GameObject diabloPrefab)
    {
        this.restartPanel = restartPanel;
        this.diabloPrefab = diabloPrefab;
    }
    
	public void Init(Game game)
	{
		_game = game;
	    GameObject.Instantiate(this.diabloPrefab);
        //this.restartPanel.SetActive(true);
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
        SceneManager.LoadScene("MainMenu");
    }
}