using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyScript : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;

    public finalScore finalScore;

    public BoxCollider2D candyCollider;

    public SpriteRenderer candyRenderer;

    public Animator candyAnim;

    public freezer freezer;
    public shaker shaker;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            freezer.Freeze();
            shaker.Shake();

            ScoreStore.collectedCollectibles++;
            candyAnim.SetBool("isPickedUp",true);
            candyCollider.enabled = false;

            Invoke("Disabler", 1);
        }
    }

    void Disabler()
    {
        candyRenderer.enabled = false;
    }
}
