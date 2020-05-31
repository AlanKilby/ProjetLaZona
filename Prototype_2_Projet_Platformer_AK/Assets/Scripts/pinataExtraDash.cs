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

    public Animator pinataAnim;

    public freezer freezer;
    public shaker shaker;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            freezer.Freeze();
            shaker.Shake();

            pinataAnim.SetBool("isRespawn", false);

            pinataAnim.SetBool("isPickedUp", true);
            playerDash.groundCheckForDashBonus = true;
            //playerInputCheckMain.canMoveHorizontally = true;
            pinataCollider.enabled = false;
            //pinataSprite.enabled = false;

            Invoke("PinataRespawn", respawnTimer);
        }
    }

    private void PinataRespawn()
    {
        pinataAnim.SetBool("isPickedUp", false);
        pinataAnim.SetBool("isRespawn", true);


        pinataCollider.enabled = true;
        pinataSprite.enabled = true;
    }
}
