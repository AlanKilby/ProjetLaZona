﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerWallInteractions : MonoBehaviour
{

    public playerControllerMain playerInputCheckMain;
    public playerJump playerJump;
    public playerDash playerDash;

    public float gravityScaleHolder;
    public float grabTimeHolder;

    public bool isWallGrabbing;

    public void WallSlide()
    {
        if (playerInputCheckMain.isJumpingUp && !isWallGrabbing)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, playerInputCheckMain.playerRB.velocity.y);
        }
        else if (playerInputCheckMain.isTouchingWall && !playerInputCheckMain.isGrounded && !isWallGrabbing || grabTimeHolder <= 0)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, -playerInputCheckMain.slideSpeed);
        }
        else if (isWallGrabbing && grabTimeHolder > 0)
        {
            playerInputCheckMain.playerRB.velocity = new Vector2(0, playerInputCheckMain.playerVerticalMovement);
            playerInputCheckMain.canMoveHorizontally = false;
            playerInputCheckMain.canFlip = false;

            if (Input.GetButtonDown("Jump"))
                playerJump.PlayerJump();
        }   
    }


    public void WallGrab()
    {
        if (playerInputCheckMain.isTouchingWall)
        {
            isWallGrabbing = true;
            playerInputCheckMain.canMoveHorizontally = false;
            playerInputCheckMain.playerRB.gravityScale = 0;
            grabTimeHolder -= Time.deltaTime;

        }
        else if (!playerInputCheckMain.isTouchingWall || playerInputCheckMain.isJumpingUp)
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
