using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;
    public playerWallInteractions playerWall;
    public playerDash playerDash;
    public playerFlip playerFlip;

    public float coyoteTimeHolder;

    public void PlayerJump()
    {
        if(playerInputCheckMain.jumpCounter > 0)
        {
            playerInputCheckMain.jumpCounter = 0;
            playerInputCheckMain.canFlip = true;

            if (playerInputCheckMain.isGrounded || coyoteTimeHolder > 0)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, playerInputCheckMain.jumpSpeed);
                coyoteTimeHolder = 0;

            }
            else if (playerInputCheckMain.isTouchingWall && !playerInputCheckMain.isGrounded)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerHorizontalMovement, playerInputCheckMain.jumpSpeed);
                Debug.Log("c suila");
                coyoteTimeHolder = 0;

            }

            if (playerInputCheckMain.playerRB.velocity.y > 0)
            {
                playerInputCheckMain.isJumpingUp = true;
            }

            if(playerInputCheckMain.playerRB.velocity.y < 0)
            {
                playerInputCheckMain.isFalling = false;
            }
            

        }

    }


    public void GrabJump()
    {
        if (playerWall.isWallGrabbing && playerFlip.isFacingRight)
        {
            playerInputCheckMain.playerRB.gravityScale = playerWall.gravityScaleHolder;
            playerInputCheckMain.playerRB.velocity = new Vector2(-3, playerInputCheckMain.jumpSpeed);
        }
        else if (playerWall.isWallGrabbing && !playerFlip.isFacingRight)
        {
            playerInputCheckMain.playerRB.gravityScale = playerWall.gravityScaleHolder;

            playerInputCheckMain.playerRB.velocity = new Vector2(3, playerInputCheckMain.jumpSpeed);
        }

        if (playerInputCheckMain.playerRB.velocity.y > 0)
        {
            playerWall.isWallGrabbing = false;

            playerInputCheckMain.isJumpingUp = true;
        }
    }

    public void BetterJump()
    {
        if (playerInputCheckMain.jumpCounter == 0 && !playerDash.isDashing)
        {
            if (playerInputCheckMain.playerRB.velocity.y <= 0)
            {
                playerInputCheckMain.playerRB.velocity += Vector2.up * Physics2D.gravity * (playerInputCheckMain.fallMultiplier - 1) * Time.deltaTime;
                playerInputCheckMain.isJumpingUp = false;
            }
            else if (!Input.GetButton("Jump") && playerInputCheckMain.playerRB.velocity.y > 0)
            {
                playerInputCheckMain.playerRB.velocity += Vector2.up * Physics2D.gravity * (playerInputCheckMain.smallFallMultiplier - 1) * Time.deltaTime;
                playerInputCheckMain.isJumpingUp = false;
            }

        }
    }


}
