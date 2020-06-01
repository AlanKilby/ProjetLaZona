using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ScoreStore : ScriptableObject
{
    public static float timer;

    public static int deathCounter;

    public static int maxCollectibles;

    public static int collectedCollectibles;

    public static float finalScoreGrade;

    // Credit Fix
    public static bool creditIsActive;
}
