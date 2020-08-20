using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DogAnimController : MonoBehaviour
{
    public List<PlayableDirector> PlayableDirectorsDog;


    // Start is called before the first frame update
    public void PlayDogAnim(int DirectorIndex)
    {
        PlayableDirectorsDog[DirectorIndex].Play();
    }

   
    
}
