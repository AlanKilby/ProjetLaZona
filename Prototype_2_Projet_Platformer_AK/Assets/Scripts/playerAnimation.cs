using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimation : MonoBehaviour
{
    public Animator playerAnim;

    public playerControllerMain playerInputCheckMain;
    public playerJump playerJump;
    public playerDash playerDash;
    public playerWallInteractions playerWall;

    private void Update()
    {
        // Idle to Running 
        if(playerInputCheckMain.isGrounded && playerInputCheckMain.playerRB.velocity.x != 0)
        {
            playerAnim.SetBool("isRunning", true);
            Debug.Log("True");
        }
        else if(playerInputCheckMain.isGrounded && playerInputCheckMain.playerRB.velocity.x == 0)
        {
            playerAnim.SetBool("isRunning", false);
        }


        // Any State to Dashing
        if (playerDash.isDashing)
        {
            playerAnim.SetBool("isDashing", true);
        }
        else
        {
            playerAnim.SetBool("isDashing", false);

        }


        //Jumping State
        if (playerInputCheckMain.isJumpingUp)
        {
            playerAnim.SetBool("isJumping", true);

        }
        else
        {
            playerAnim.SetBool("isJumping", false);

        }
    }
}
