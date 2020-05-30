using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class finalScoreScreen : MonoBehaviour
{
    public finalScore scoreChecker;

    public Text deaths;

    public Text candy;

    public Text timer;

    public Text grade;

    public string scoreGrade;


    private void Update()
    {
        deaths.text = "Total Deaths : " + scoreChecker.deathCounter;
        candy.text = "Total Candy Collected : " + scoreChecker.collectedCollectibles + " / " + scoreChecker.maxCollectibles;
        timer.text = "Total Time : " + scoreChecker.timer;

        if (scoreChecker.finalScoreGrade >= 30)
        {
            scoreGrade = "A";
        }

        if (scoreChecker.finalScoreGrade < 30 && scoreChecker.finalScoreGrade >= 5)
        {
            scoreGrade = "B";
        }
        if (scoreChecker.finalScoreGrade < 5 && scoreChecker.finalScoreGrade >= -30)
        {
            scoreGrade = "C";
        }
        if (scoreChecker.finalScoreGrade < -30)
        {
            scoreGrade = "D";
        }

        grade.text = "Final Grade : " + scoreGrade;

    }





}
