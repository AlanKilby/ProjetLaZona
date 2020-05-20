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

        if(playerInputCheckMain.isGrounded && playerInputCheckMain.playerHorizontalMovement == 0 || playerInputCheckMain.isTouchingWall)
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


        ////Jumping State
        //if (Input.GetKey("Jump") && playerInputCheckMain.isGrounded == false)
        //{
        //    playerAnim.SetBool("isJumping", true);

        //}

        //else 
        //{
        //    playerAnim.SetBool("isJumping", false);

        //}


        //Grabbing State
        if (playerWall.isWallGrabbing)
        {
            playerAnim.SetBool("isWallGrabbing", true);
        }
        
        if(!playerWall.isWallGrabbing)
        {
            playerAnim.SetBool("isWallGrabbing", false);
        }


        //Climbing State
        if (playerWall.isWallGrabbing && playerInputCheckMain.playerVerticalMovement > 0)
        {
            playerAnim.SetBool("isClimbing", true);
            playerAnim.SetBool("isRunning", false);

        }
        else
        {
            playerAnim.SetBool("isClimbing", false);
        }
    }
}
