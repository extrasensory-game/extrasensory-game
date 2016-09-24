using UnityEngine;
using UnityEngine.UI;

public class WaitClientMode : IMode
{
    private bool waiting = true;
    private readonly GameObject nextClientCanvasPrefab;
    private GameObject nextClientCanvas;

    public WaitClientMode(GameObject nextClientCanvasPrefab)
    {
        this.nextClientCanvasPrefab = nextClientCanvasPrefab;
    }

    public void Init()
    {
        this.nextClientCanvas = GameObject.Instantiate(this.nextClientCanvasPrefab);
        nextClientCanvas.GetComponentInChildren<Button>().onClick.AddListener(CallNextClient);
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
        GameObject.Destroy(this.nextClientCanvas);
    }

    private void CallNextClient()
    {
        Debug.Log("Call next client");
        waiting = false;
    }
}