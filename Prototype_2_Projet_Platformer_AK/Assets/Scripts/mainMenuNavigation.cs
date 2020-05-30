using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuNavigation : MonoBehaviour
{

    public GameObject creditCanvas;
     bool creditIsActive;
    public void PlayGame()
    {
        SceneManager.LoadScene("AK_Main_Scene");
    }


    public void Credits()
    {
        creditCanvas.SetActive(true);
        creditIsActive = true;
    }

    public void Options()
    {
        SceneManager.LoadScene("Options_Scene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(creditIsActive == true && Input.anyKey)
        {
            creditCanvas.SetActive(false);
            creditIsActive = false;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
