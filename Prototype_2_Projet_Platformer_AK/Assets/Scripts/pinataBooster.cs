using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinataBooster : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    public playerDash playerDash;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            playerDash.dashTimeLeft += playerInputCheckMain.dashTime;
            Destroy(gameObject);
        }
    }
}
