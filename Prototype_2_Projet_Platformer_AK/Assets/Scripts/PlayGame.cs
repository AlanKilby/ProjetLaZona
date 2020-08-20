using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayGameDirect",69);
    }

    void PlayGameDirect()
    {
        SceneManager.LoadScene("AK_Main_Scene");

    }
}
