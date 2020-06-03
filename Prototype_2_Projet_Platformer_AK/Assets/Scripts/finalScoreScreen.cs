using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class finalScoreScreen : MonoBehaviour
{
    public Text deaths;

    public Text candy;

    public Text timer;

    public Text grade;

    public string scoreGrade;


    private void Start()
    {
        

        if (ScoreStore.finalScoreGrade >= -120)
        {
            scoreGrade = "A";
        }

        if (ScoreStore.finalScoreGrade < - 120 && ScoreStore.finalScoreGrade >= -200)
        {
            scoreGrade = "B";
        }
        if (ScoreStore.finalScoreGrade < -200 && ScoreStore.finalScoreGrade >= -280)
        {
            scoreGrade = "C";
        }
        if (ScoreStore.finalScoreGrade < -280)
        {
            scoreGrade = "D";
        }

        timer.text = "Total Time : " + (ScoreStore.timer);

        deaths.text = "Total Deaths : " + (ScoreStore.deathCounter);

        candy.text = "Total Candy Collected : " + ScoreStore.collectedCollectibles + " / " + ScoreStore.maxCollectibles;

        grade.text = "Final Grade : " + scoreGrade;

        Debug.Log(ScoreStore.timer);
        Debug.Log(ScoreStore.deathCounter);
        Debug.Log(ScoreStore.collectedCollectibles);
        Debug.Log(scoreGrade);
    }





}
