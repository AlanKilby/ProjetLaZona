using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallInteractions : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;
    public playerJump playerJump;
    public playerDash playerDash;

    public float gravityScaleHolder;
    public float grabTimeHolder;
    public float climbingSpeed;

    public bool isWallGrabbing;

    public void WallSlide()
    {
        if (playerInputCheckMain.isJumpingUp && !isWallGrabbing)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, playerInputCheckMain.playerRB.velocity.y);
        }
        
        else if (playerInputCheckMain.isTouchingWall && !playerInputCheckMain.isGrounded && !isWallGrabbing)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, -playerInputCheckMain.slideSpeed);
        }
        
        else if (isWallGrabbing)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(0, playerInputCheckMain.playerVerticalMovement);
            playerInputCheckMain.canMoveHorizontally = false;
            playerInputCheckMain.canFlip = false;
            playerInputCheckMain.isGrounded = false;

            if (Input.GetButtonDown("Jump") && playerInputCheckMain.playerVerticalMovement == 0)
            {
                playerInputCheckMain.canFlip = true;

                playerJump.GrabJump();
            }
            else if (Input.GetButtonDown("Jump") && playerInputCheckMain.playerRB.velocity.y > 0)
            {
                Debug.Log("ITS USING THE RIGHT JUMP");
                playerInputCheckMain.canMoveHorizontally = true;

                playerInputCheckMain.playerRB.velocity = new Vector2(0, 0);

                playerInputCheckMain.canFlip = true;

                playerJump.GrabJumpFix();

            }

            if (playerInputCheckMain.playerVerticalMovement != 0)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(0, playerInputCheckMain.playerRB.velocity.y * climbingSpeed);

            }
            
            
        }

    }


    public void WallGrab()
    {
        if (playerInputCheckMain.isTouchingWall && grabTimeHolder > 0)
        {
            isWallGrabbing = true;
            playerInputCheckMain.canMoveHorizontally = false;
            playerInputCheckMain.playerRB.gravityScale = 0;
            grabTimeHolder -= Time.deltaTime;

        }
        else if (!playerInputCheckMain.isTouchingWall || playerInputCheckMain.isJumpingUp || grabTimeHolder <=0)
        {
            isWallGrabbing = false;
            playerInputCheckMain.playerRB.gravityScale = gravityScaleHolder;
            playerInputCheckMain.canMoveHorizontally = true;
            playerInputCheckMain.canFlip = true;


        }
        
    }

    public void NotWallGrabbing()
    {
        if(!playerInputCheckMain.isTouchingWall || !Input.GetButton("Grab"))
        {
            isWallGrabbing = false;
            playerInputCheckMain.playerRB.gravityScale = gravityScaleHolder;
            playerInputCheckMain.canMoveHorizontally = true;
            playerInputCheckMain.canFlip = true;


        }
    }
}
