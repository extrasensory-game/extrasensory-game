using UnityEngine;
using UnityEngine.UI;

public class WaitClientMode : IMode
{
    private bool waiting = true;
    private readonly GameObject nextClientPanel;

    public WaitClientMode(GameObject nextClientPanel)
    {
        this.nextClientPanel = nextClientPanel;
    }

    public void Init()
    {
        this.nextClientPanel.SetActive(true);
        this.nextClientPanel.GetComponentInChildren<Button>().onClick.AddListener(CallNextClient);
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
        this.nextClientPanel.GetComponentInChildren<Button>().onClick.RemoveListener(CallNextClient);
    }

    private void CallNextClient()
    {
        Debug.Log("Call next client");
        waiting = false;
    }
}