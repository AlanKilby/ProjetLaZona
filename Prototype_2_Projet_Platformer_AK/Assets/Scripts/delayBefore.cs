using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayBefore : MonoBehaviour
{
    public GameObject canvas;
    public float spawnTime;
    void Start()
    {
        canvas.SetActive(false);

        Invoke("GoBackActive", spawnTime);
    }


    void GoBackActive()
    {
        canvas.SetActive(true);
    }
}
