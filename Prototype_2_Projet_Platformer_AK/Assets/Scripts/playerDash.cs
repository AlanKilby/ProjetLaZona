using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDash : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;
    public playerFlip playerFlip;
    public playerWallInteractions playerWall;
    public freezer freezer;
    public shaker shaker;
    public SoundManagement soundManager;

    public bool isDashing;
    public bool groundCheckForDash;
    public bool groundCheckForDashBonus;

    public float dashTimeLeft;
    public void CheckDashGround()
    {
        if(playerInputCheckMain.isGrounded)
        {
            groundCheckForDash = true; //Gives the dash CD
        }
    }

    public void DashAttempt()
    {
        if (groundCheckForDash)
        {

            freezer.Freeze();
            shaker.Shake();
            isDashing = true;
            dashTimeLeft = playerInputCheckMain.dashTime;
            groundCheckForDash = false;
            playerInputCheckMain.canFlip = true;

            playerInputCheckMain.dashParticles.SetActive(true);

            soundManager.dash.Play();


        }

        if (groundCheckForDashBonus)
        {

            freezer.Freeze();
            shaker.Shake();
            isDashing = true;
            dashTimeLeft = playerInputCheckMain.dashTime;
            groundCheckForDashBonus = false;
            playerInputCheckMain.canFlip = true;

            playerInputCheckMain.dashParticles.SetActive(true);

            soundManager.dash.Play();


        }
    }

    public void CheckDash()
    {
        if (isDashing)
        {

            groundCheckForDash = false;
            if (dashTimeLeft > 0 && (playerInputCheckMain.playerHorizontalMovement != 0 || playerInputCheckMain.playerVerticalMovement != 0))
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.dashSpeed * playerInputCheckMain.playerHorizontalMovement, playerInputCheckMain.dashSpeed * playerInputCheckMain.playerVerticalMovement);

                dashTimeLeft -= Time.deltaTime;

                Debug.Log("Ca passe par le premier dash.");

                playerInputCheckMain.canMove = false;
                
            }
            else if(dashTimeLeft > 0)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.dashSpeed * playerFlip.playerIsLooking, playerInputCheckMain.dashSpeed * playerInputCheckMain.playerVerticalMovement);

                dashTimeLeft -= Time.deltaTime;
                Debug.Log("Ca passe par le 2 dash.");

                playerInputCheckMain.canMove = false;

            }


            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerRB.velocity.x, 0);

                playerInputCheckMain.canMove = true;

                

            }


        }
        else if (!isDashing)
        {

            playerInputCheckMain.dashParticles.SetActive(false);

        }


    }


    
    private void NoMoreParticles()
    {
        
    }

    //public void WallDash()
    //{
    //    if (isDashing)
    //    {
    //        groundCheckForDash = false;
    //        if(dashTimeLeft > 0 && playerWall.isWallGrabbing && (playerInputCheckMain.playerHorizontalMovement != 0 || playerInputCheckMain.playerVerticalMovement != 0))
    //        {
    //            playerInputCheckMain.playerRB.velocity = new Vector2 (playerInputCheckMain.playerVerticalMovement*playerInputCheckMain.dashSpeed, playerInputCheckMain.playerHorizontalMovement*playerInputCheckMain.dashSpeed)
    //            dashTimeLeft -= Time.deltaTime;

    //        }
    //        else if(dashTimeLeft > 0)
    //        {
    //            playerInputCheckMain.playerRB.velocity = new Vector2(playerFlip.playerIsLooking*playerInputCheckMain.dashSpeed, playerInputCheckMain.playerRB.velocity.y);
    //            dashTimeLeft -= Time.deltaTime;
    //        }
    //    }

    //}
}
