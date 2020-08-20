using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationTrigger : MonoBehaviour
{
    public PlayableDirector DogDirector;
    public BoxCollider2D triggerCollider;
    public GameObject dog;
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            dog.SetActive(true);

            DogDirector.Play();

            triggerCollider.enabled = false;

        }

    }
   
}
