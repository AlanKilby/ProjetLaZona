using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinataBooster : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    public playerDash playerDash;

    public BoxCollider2D boosterCollider;

    public SpriteRenderer boosterSprite;

    public float respawnTimer;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            playerDash.dashTimeLeft += playerInputCheckMain.dashTime;

            boosterCollider.enabled = false;

            boosterSprite.enabled = false;

            Invoke("BoosterRespawn", respawnTimer);
        }
    }

    private void BoosterRespawn()
    {
        boosterCollider.enabled = true;
        boosterSprite.enabled = true;
    }
}
