﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerMain : MonoBehaviour
{
    // Script Referencing
    public playerMovement playerMovement;
    public playerJump playerJump;
    public playerDash playerDash;
    public playerFlip playerFlip;
    public playerWallInteractions playerWall;

    public GameObject dashParticles;
    
    public float playerHorizontalMovement;
    public float playerVerticalMovement;
    public float checkRadius;
    public float jumpCounter = 1;
    public float jumpSpeed;
    public float movementSpeed;
    public float dashTime;
    public float dashSpeed;
    public float wallCheckDistance;
    public float fallMultiplier;
    public float smallFallMultiplier;
    public float slideSpeed;
    public float grabTime;
    public float coyoteTime;


    public Vector3 respawnPoint;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask ground;
    [HideInInspector] public Rigidbody2D playerRB;

    public bool isGrounded;
    public bool isTouchingWall;
    public bool isJumpingUp;
    public bool isFalling;
    public bool canMoveHorizontally;
    public bool canMoveVertically;
    public bool canMove;
    public bool canFlip;
    public bool justJumped;
    public bool hasControl;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerWall.gravityScaleHolder = playerRB.gravityScale;
        canMoveHorizontally = true;
        canFlip = true;
        playerWall.grabTimeHolder = grabTime;
        canMove = true;
        playerJump.coyoteTimeHolder = coyoteTime;
        justJumped = false;

        dashParticles.SetActive(false);

        hasControl = true;

        

    }

    // Update is called once per frame
    void Update()
    {
        InputCheckMain();
        CoyoteTime();
        playerMovementDirections();
        playerDash.CheckDashGround();
        playerWall.WallSlide();
    }

    private void FixedUpdate()
    {
        SurroundingsCheck();
        playerMovement.PlayerHorizontalMovement();
        playerJump.BetterJump();
        playerDash.CheckDash();


    }


    public void InputCheckMain()
    {
        if (hasControl)
        {
            if (canMove)
            {
                playerHorizontalMovement = Input.GetAxisRaw("Horizontal");
                playerVerticalMovement = Input.GetAxisRaw("Vertical");
            }

            if (Input.GetButtonDown("Jump") && !playerWall.isWallGrabbing)
            {
                playerJump.PlayerJump();


            }

            if (Input.GetButtonDown("Dash"))
            {
                playerDash.DashAttempt();


            }


            // Jump Counter reset
            if (isJumpingUp)
            {
                jumpCounter = 0;
            }
            else if (!isGrounded && !isTouchingWall && playerJump.coyoteTimeHolder < 0)
            {
                jumpCounter = 0;
            }
            else if (isGrounded || isTouchingWall)
            {
                jumpCounter = 1;

            }

            if (isGrounded)
            {
                playerWall.grabTimeHolder = grabTime;
                justJumped = false;
            }


            if (Input.GetButton("Grab") && !isJumpingUp)
            {
                playerWall.WallGrab();
            }
            else if (!Input.GetButton("Grab"))
            {
                playerWall.NotWallGrabbing();
            }
        }
        
    }

    

    public void SurroundingsCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, ground);
        isTouchingWall = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, ground);
    }

    public void playerMovementDirections()
    {

        if(playerHorizontalMovement > 0 && !playerFlip.isFacingRight)
        {
            playerFlip.FlipSprite();
        }
        else if (playerHorizontalMovement < 0 && playerFlip.isFacingRight)
        {
            playerFlip.FlipSprite();
        }

        if (playerHorizontalMovement == 1)
        {
            playerFlip.playerIsLooking = 1;
        }
        else if (playerHorizontalMovement == -1)
        {
            playerFlip.playerIsLooking = -1;
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));


    }

    public void CoyoteTime()
    {

        if (!isGrounded)
        {
            playerJump.coyoteTimeHolder -= Time.deltaTime;
        }

        if (isGrounded)
        {
            playerJump.coyoteTimeHolder = coyoteTime;

        }
    }
}
