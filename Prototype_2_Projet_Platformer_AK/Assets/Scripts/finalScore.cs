using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;


public class finalScore : MonoBehaviour
{
    

    public bool stopScore;

    public GameObject ScoreCanvas;

    public int currentDeaths;

    public int maxCollectibles;

    public TransitionManager transitionManager;


    public void Start()
    {
        ScoreCanvas.SetActive(false);
        ScoreStore.deathCounter = currentDeaths;
        ScoreStore.maxCollectibles = maxCollectibles;
        ScoreStore.collectedCollectibles = 0;
        stopScore = false;
    }
    public void Update()
    {
        if (!stopScore)
        {
            ScoreStore.timer += Time.deltaTime;

            Debug.Log(ScoreStore.timer);
        }
        if (stopScore)
        {
            Invoke("NextScene", 1);
        }

        Debug.Log(ScoreStore.deathCounter);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Invoke("Transition", 0.1f);
            stopScore = true;
            ScoreStore.finalScoreGrade = FinalGradeCalculator();
            
        }
    }

    public void NextScene()
    {

        SceneManager.LoadScene("FinalScore");

    }

    public float FinalGradeCalculator()
    {
        ScoreStore.finalScoreGrade = ((ScoreStore.collectedCollectibles / ScoreStore.maxCollectibles) * 100) - ScoreStore.deathCounter - (ScoreStore.timer / 2);

        return ScoreStore.finalScoreGrade;
    }

    public void Transition()
    {
        transitionManager.transitionsAnim.SetTrigger("end");

    }
}
