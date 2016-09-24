using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMode : IMode
{
    private readonly GameObject restartPanel;

    public EndMode(GameObject restartPanel)
    {
        this.restartPanel = restartPanel;
    }
    
    public void Init()
    {
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