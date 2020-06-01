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



        // Any State WallSlide
        if(playerInputCheckMain.isTouchingWall && !playerWall.isWallGrabbing && !playerInputCheckMain.isGrounded)
        {
            playerAnim.SetBool("isWallSliding", true);
        }
        else
        {
            playerAnim.SetBool("isWallSliding", false);

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
        

        //Grounded Check
        if (!playerInputCheckMain.isGrounded)
        {
            playerAnim.SetBool("isGrounded", false);

        }
        else if (playerInputCheckMain.isGrounded)
        {
            playerAnim.SetBool("isGrounded", true);

        }

        

        // Climbing

        if(playerWall.isWallGrabbing && playerInputCheckMain.playerRB.velocity.y > 0)
        {
            playerAnim.SetBool("isClimbing", true);
            playerAnim.SetBool("isWallGrabbing", false);


        }
        else if (!playerWall.isWallGrabbing)
        {
            playerAnim.SetBool("isClimbing", false);

        }


        // Touching Wall

        if (playerInputCheckMain.isTouchingWall)
        {
            playerAnim.SetBool("isTouchingWall", true);

        }
        else
        {
            playerAnim.SetBool("isTouchingWall", false);

        }

        //Jump
        if(playerInputCheckMain.coyoteTime > 0 && Input.GetButtonDown("Jump"))
        {
            playerAnim.SetBool("isJumping", true);

            playerAnim.SetBool("isRunning", false);

            Invoke("JumpEnd", 0.5f);
        }


        if(playerWall.isWallGrabbing && Input.GetButtonDown("Jump") && playerInputCheckMain.playerRB.velocity.y != 0)
        {
            JumpEnd();
        }

        
    }

    public void JumpEnd()
    {
        playerAnim.SetBool("isJumping", false);

    }
}
