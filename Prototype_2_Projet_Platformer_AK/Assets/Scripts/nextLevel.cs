using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextLevel : MonoBehaviour
{
    public TransitionManager transitionManager;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Invoke("Transition",0.1f);
            Invoke("NextLevelTrigger", 1);
            Debug.Log("Player Triggered");
        }
    }


    public void NextLevelTrigger()
    {
        SceneManager.LoadScene("CM_Cimetière+ville");

    }

    public void Transition()
    {
        transitionManager.transitionsAnim.SetTrigger("end");

    }
}
