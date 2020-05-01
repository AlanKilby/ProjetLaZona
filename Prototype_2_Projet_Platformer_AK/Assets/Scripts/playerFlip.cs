using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlip : MonoBehaviour
{
    public playerControllerMain playerInputCheckMain;

    public bool isFacingRight = true;
    public float playerIsLooking;
    public void FlipSprite()
    {
        if (playerInputCheckMain.canFlip)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0f);
        }
    
    }
}
