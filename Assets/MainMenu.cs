using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void DualPlayGame()
    {
        SceneManager.LoadScene(2);
    }
    public void PlayGround()
    {
        SceneManager.LoadScene(3);
    }
    public void SinglePlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quitgame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
