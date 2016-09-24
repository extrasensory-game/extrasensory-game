using UnityEngine;
using System.Collections;
using ExtrasensoryGame.Assets.Scripts.Intro;
using UnityEngine.SceneManagement;

public class DiabloEntering : MonoBehaviour
{
    [SerializeField]
    private ScrollPanel scrollPanel;
    
    public void OnAnimationEnd()
    {
        StartCoroutine(WaitAndOpenPanel()); 
    }

    private IEnumerator WaitAndOpenPanel()
    {
        yield return new WaitForSeconds(1);
        scrollPanel.OpenPanel();
    }

    public void Leave()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Leave");
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Main");
    }
}
