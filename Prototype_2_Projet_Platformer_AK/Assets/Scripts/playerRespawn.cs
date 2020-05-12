using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillZone")
        {
            playerInputCheckMain.playerRB.position = playerInputCheckMain.respawnPoint;
        }

        if(collision.tag == "Checkpoint")
        {
            playerInputCheckMain.respawnPoint = collision.transform.position;
        }
    }
}
