using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScore : MonoBehaviour
{
    public float timer;
    public float deathCounter;
    public float maxCollectibles;
    public float collectedCollectibles;

    public bool stopScore;


    public void Start()
    {
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

        Debug.Log(deathCounter);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            stopScore = true;
        }
    }
}
