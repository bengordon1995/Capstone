using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void PlayGame ()
    {
        SceneManager.LoadScene("Entrance");
    }

    public void HelpGame()
    {
        SceneManager.LoadScene("Help");
    }

    public void BackHelp()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
