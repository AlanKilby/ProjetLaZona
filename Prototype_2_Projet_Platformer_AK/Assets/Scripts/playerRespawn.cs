using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRespawn : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    public finalScore finalScore;

    public Animator playerAnim;

    public freezer freezer;

    public shaker shaker;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "KillZone" || collision.tag == "Spikes")
        {
            freezer.Freeze();
            shaker.Shake();

            playerInputCheckMain.hasControl = false;
            playerInputCheckMain.playerVerticalMovement = 0;
            playerInputCheckMain.playerHorizontalMovement = 0;
            
            playerInputCheckMain.playerRB.velocity = new Vector2(0, 0);
            playerAnim.SetBool("Death", true);
            playerAnim.SetBool("Respawn", false);


            Invoke("Respawn", 1);
            ScoreStore.deathCounter++;
        }

        if(collision.tag == "Checkpoint")
        {
            playerInputCheckMain.respawnPoint = collision.transform.position;
        }
    }

    public void Respawn()
    {
        playerInputCheckMain.playerRB.position = playerInputCheckMain.respawnPoint;
        playerAnim.SetBool("Death", false);
        playerAnim.SetBool("Respawn", true);
        //playerInputCheckMain.hasControl = true;

        Invoke("MoveAgain",1);
    }

    public void MoveAgain()
    {

        playerInputCheckMain.hasControl = true;
        playerAnim.SetBool("Respawn", false);

    }
}
