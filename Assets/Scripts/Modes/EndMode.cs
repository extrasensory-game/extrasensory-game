using System;
using UnityEngine.SceneManagement;

public class EndMode : IMode
{
    public void Init()
    {
        SceneManager.LoadScene("Intro");
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public bool IsFinished()
    {
        throw new NotImplementedException();
    }

    public void Deinit()
    {
        throw new NotImplementedException();
    }
}