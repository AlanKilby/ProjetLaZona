using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinataExtraDash : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;

    public playerDash playerDash;

    public BoxCollider2D pinataCollider;

    public SpriteRenderer pinataSprite;

    public float respawnTimer;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            playerDash.groundCheckForDashBonus = true;
            //playerInputCheckMain.canMoveHorizontally = true;
            pinataCollider.enabled = false;
            pinataSprite.enabled = false;

            Invoke("PinataRespawn", respawnTimer);
        }
    }

    private void PinataRespawn()
    {
        pinataCollider.enabled = true;
        pinataSprite.enabled = true;
    }
}
