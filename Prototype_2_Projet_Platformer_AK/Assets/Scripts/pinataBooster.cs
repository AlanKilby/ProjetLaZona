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

    public Animator boosterAnim;

    public freezer freezer;
    public shaker shaker;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            freezer.Freeze();
            shaker.Shake();

            boosterAnim.SetBool("isRespawn", false);

            boosterAnim.SetBool("isPickedUp", true);

            playerDash.dashTimeLeft += playerInputCheckMain.dashTime;

            boosterCollider.enabled = false;


            Invoke("BoosterRespawn", respawnTimer);
        }
    }

    private void BoosterRespawn()
    {
        boosterAnim.SetBool("isRespawn", true);

        boosterAnim.SetBool("isPickedUp", false);

        boosterCollider.enabled = true;
        boosterSprite.enabled = true;
    }
}
