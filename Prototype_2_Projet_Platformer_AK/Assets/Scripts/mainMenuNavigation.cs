using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuNavigation : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Intro_Cutscene");
    }


    public void Credits()
    {
        SceneManager.LoadScene("Credits_Scene");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
