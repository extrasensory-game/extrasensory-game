using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndMode : IMode
{
    private readonly GameObject restartCanvasPrefab;

    public EndMode(GameObject restartCanvasPrefab)
    {
        this.restartCanvasPrefab = restartCanvasPrefab;
    }
    
    public void Init()
    {
        var restartCanvas = GameObject.Instantiate(this.restartCanvasPrefab);
        restartCanvas.GetComponentInChildren<Button>().onClick.AddListener(Restart);
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