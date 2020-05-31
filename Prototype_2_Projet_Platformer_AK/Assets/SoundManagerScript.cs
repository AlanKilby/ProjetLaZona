using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip CandySound, DashSound, DeathSound, JumpSound, PinataSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        CandySound = Resources.Load<AudioClip>("Candy4");
        DashSound = Resources.Load<AudioClip>("Dash1");
        DeathSound = Resources.Load<AudioClip>("Death1");
        JumpSound = Resources.Load<AudioClip>("Jump");
        PinataSound = Resources.Load<AudioClip>("Pinata5");

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
            case "Candy4":
                audioSrc.PlayOneShot(CandySound);
                break;
            case "Dash1":
                audioSrc.PlayOneShot(DashSound);
                break;
            case "Death1":
                audioSrc.PlayOneShot(DeathSound);
                break;
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "¨Pinata5":
                audioSrc.PlayOneShot(PinataSound);
                break;
        }
    }
}
