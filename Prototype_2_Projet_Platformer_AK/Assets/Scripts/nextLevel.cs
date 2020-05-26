using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Invoke("NextLevelTrigger", 1);
            Debug.Log("Player Triggered");
        }
    }


    public void NextLevelTrigger()
    {
        SceneManager.LoadScene("CM_Cimetière+ville");

    }
}
