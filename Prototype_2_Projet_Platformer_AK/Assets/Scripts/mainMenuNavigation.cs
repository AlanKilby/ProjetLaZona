﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuNavigation : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("AK_Main_Scene");
    }


    public void Credits()
    {
        SceneManager.LoadScene("Credits_Scene");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options_Scene");
    }

}