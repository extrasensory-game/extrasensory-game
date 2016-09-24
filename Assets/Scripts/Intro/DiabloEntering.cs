using UnityEngine;
using System.Collections;
using ExtrasensoryGame.Assets.Scripts.Intro;

public class DiabloEntering : MonoBehaviour
{
    [SerializeField]
    private ScrollPanel scrollPanel;
    
    public void OnAnimationEnd()
    {
        scrollPanel.OpenPanel();
    }
}
