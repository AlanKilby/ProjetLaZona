using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class MenuMusic : MonoBehaviour
{

    public AudioSource titleIntro;
    public AudioSource titleLoop;
    public float lenghtHolder;

    // Start is called before the first frame update
    void Start()
    {
        lenghtHolder = titleIntro.clip.length;
        Invoke("playIntro", 5);
        Invoke("playLoop", (lenghtHolder+5));
    }

    public void playLoop()
    {
        titleLoop.Play();
    }

    public void playIntro()
    {
        titleIntro.Play();
    }
}
