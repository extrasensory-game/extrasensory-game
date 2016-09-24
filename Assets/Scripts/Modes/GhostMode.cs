using UnityEngine;

public class GhostMode : IMode
{
    public void Init()
    {
        Debug.Log("GhostMode.Init");
    }

    public void Update()
    {
        Debug.Log("GhostMode.Update");
    }

    public void Deinit()
    {
        Debug.Log("GhostMode.Deinit");
    }
}