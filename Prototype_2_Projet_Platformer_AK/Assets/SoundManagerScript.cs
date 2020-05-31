using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip Candysound, Dashsound, Deathsound, Jumpsound, Pinatasound;
    static AudioSource audioSrc;
    
    // Start is called before the first frame update
    void Start()
    {
        Dashsound = Resources.Load<AudioClip>("Dash1");
        Candysound = Resources.Load<AudioClip>("Candy4");
        Deathsound = Resources.Load<AudioClip>("Death1");
        Jumpsound = Resources.Load<AudioClip>("Jump");
        Pinatasound = Resources.Load<AudioClip>("Pinata5");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Dash1":
                audioSrc.PlayOneShot(Dashsound);
                break;
            case "Candy4":
                audioSrc.PlayOneShot(Candysound);
                break;
            case "Death1":
                audioSrc.PlayOneShot(Deathsound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(Jumpsound);
                break;
            case "Pinata5":
                audioSrc.PlayOneShot(Pinatasound);
                break;
        }
    }
}
