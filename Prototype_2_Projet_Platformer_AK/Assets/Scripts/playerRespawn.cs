using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    public finalScore finalScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillZone" || collision.tag == "Spikes")
        {
            playerInputCheckMain.playerRB.position = playerInputCheckMain.respawnPoint;
            finalScore.deathCounter++;
        }

        if(collision.tag == "Checkpoint")
        {
            playerInputCheckMain.respawnPoint = collision.transform.position;
        }
    }
}
