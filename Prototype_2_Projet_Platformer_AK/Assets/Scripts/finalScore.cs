using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;


public class finalScore : MonoBehaviour
{
    public float timer;
    public float deathCounter;
    public float maxCollectibles;
    public float collectedCollectibles;
    public float finalScoreGrade;

    public bool stopScore;

    public GameObject ScoreCanvas;


    public void Start()
    {
        ScoreCanvas.SetActive(false);
        deathCounter = 0;
        collectedCollectibles = 0;
        stopScore = false;
    }
    public void Update()
    {
        if (!stopScore)
        {
            timer += Time.deltaTime;

            Debug.Log(timer);
        }
        if (stopScore)
        {
            Invoke("StopTime", 3);
        }

        Debug.Log(deathCounter);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            stopScore = true;
            finalScoreGrade = FinalGradeCalculator();
        }
    }

    public void StopTime()
    {
        Time.timeScale = 0;

        ScoreCanvas.SetActive(true);

    }

    public float FinalGradeCalculator()
    {
        finalScoreGrade = ((collectedCollectibles / maxCollectibles) * 100) - deathCounter - (timer / 2);

        return finalScoreGrade;
    }
}
