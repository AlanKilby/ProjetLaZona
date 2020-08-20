using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    public DogAnimController DogAnimController;
    public int AnimationIndex;
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            DogAnimController.PlayDogAnim(AnimationIndex);
        }
    }
   
}
