using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManagement : MonoBehaviour
{
    public AudioMixerGroup master;
    public AudioSource jump;
    public AudioSource dash;
    public AudioSource death;
    public AudioSource candy;
    public AudioSource pinata;

    private void Start()
    {
        jump.outputAudioMixerGroup = master;
        dash.outputAudioMixerGroup = master;
        death.outputAudioMixerGroup = master;
        candy.outputAudioMixerGroup = master;
        pinata.outputAudioMixerGroup = master;

    }
}
