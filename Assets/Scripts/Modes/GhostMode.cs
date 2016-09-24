using UnityEngine;

public class GhostMode : IMode
{
    public void Init()
    {
    }

    public void Update()
    {
    }

    private int _framesCount = 0;
    public bool IsFinished()
    {
        ++_framesCount;
        return _framesCount > 200;
    }

    public void Deinit()
    {
    }
}