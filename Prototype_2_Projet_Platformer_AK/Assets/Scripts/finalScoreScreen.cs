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
        

        if (ScoreStore.finalScoreGrade >= 30)
        {
            scoreGrade = "A";
        }

        if (ScoreStore.finalScoreGrade < 30 && ScoreStore.finalScoreGrade >= 5)
        {
            scoreGrade = "B";
        }
        if (ScoreStore.finalScoreGrade < 5 && ScoreStore.finalScoreGrade >= -30)
        {
            scoreGrade = "C";
        }
        if (ScoreStore.finalScoreGrade < -30)
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
