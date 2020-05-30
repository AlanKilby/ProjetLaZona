using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class candyScript : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;

    public finalScore finalScore;

    public BoxCollider2D candyCollider;

    public SpriteRenderer candyRenderer;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            ScoreStore.collectedCollectibles++;
            candyCollider.enabled = false;
            candyRenderer.enabled = false;
        }
    }
}
