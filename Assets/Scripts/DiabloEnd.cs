using ExtrasensoryGame;
using UnityEngine;

public class DiabloEnd : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        var uiManager = GameObject.FindObjectOfType<UIManager>();
        uiManager.RestartPanel.SetActive(true);
    }
}