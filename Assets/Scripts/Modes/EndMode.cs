using System;
using UnityEngine;

public class EndMode : IMode
{
    private readonly GameObject restartCanvas;

    public EndMode(GameObject restartCanvas)
    {
        this.restartCanvas = restartCanvas;
    }
    
    public void Init()
    {
        GameObject.Instantiate(this.restartCanvas);
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
}