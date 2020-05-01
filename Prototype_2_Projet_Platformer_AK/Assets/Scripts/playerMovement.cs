using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;
    public void PlayerHorizontalMovement()
    {
        if (playerInputCheckMain.canMoveHorizontally)
        {
            if (playerInputCheckMain.playerHorizontalMovement != 0)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(playerInputCheckMain.playerHorizontalMovement * playerInputCheckMain.movementSpeed, playerInputCheckMain.playerRB.velocity.y);
            }
            if (playerInputCheckMain.playerHorizontalMovement == 0)
            {
                playerInputCheckMain.playerRB.velocity = new Vector2(0, playerInputCheckMain.playerRB.velocity.y);
            }
        }
         
    }
}
