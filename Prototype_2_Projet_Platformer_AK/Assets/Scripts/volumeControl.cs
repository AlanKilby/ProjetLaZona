using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SocialPlatforms.Impl;

public class volumeControl : MonoBehaviour
{

    public void SetVolume(float volume)
    {
        ScoreStore.volume = volume;
    }
}
