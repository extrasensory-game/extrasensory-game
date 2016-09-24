using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBehavior : MonoBehaviour
{
    public void Restart()
    {
        Debug.Log("restart");
        SceneManager.LoadScene("Intro");
    }
}