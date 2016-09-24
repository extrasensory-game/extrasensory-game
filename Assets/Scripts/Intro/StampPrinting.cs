using UnityEngine;
using System.Collections;
using ExtrasensoryGame.Assets.Scripts.Intro;
using UnityEngine.UI;

public class StampPrinting : MonoBehaviour
{
    [SerializeField]
    private Image stamp;
    [SerializeField]
    private ScrollPanel scrollPanel;
    public void OnStampActive()
    {
        stamp.gameObject.SetActive(true);
    }

    public void OnHandUp()
    {
        gameObject.SetActive(false);
        scrollPanel.ClosePanel();
    }

    public void MakeAStamp()
    {
        StartCoroutine(WaitAndMakeStamp());
    }

    private IEnumerator WaitAndMakeStamp()
    {
        yield return new WaitForSeconds(5);
    }
}
