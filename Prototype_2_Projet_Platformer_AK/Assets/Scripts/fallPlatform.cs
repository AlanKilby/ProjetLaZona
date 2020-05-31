using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallPlatform : MonoBehaviour
{
    public Rigidbody2D platformRB;
    //public Transform groundcheck1;
    public Transform groundcheck2;
    //public Transform groundcheck3;

    public LayerMask ground;


    public float fallingSpeed;
    public float standingTime;
    public float checkDistance;

    public bool isTouchingGround;

    public Vector3 initialPosition;

    public Animator platformAnim;

    void Start()
    {
        platformRB = GetComponent<Rigidbody2D>();
        platformRB.gravityScale = 0;
        initialPosition = platformRB.transform.position;
    }
    private void Update()
    {
        
        isTouchingGround = Physics2D.Raycast(groundcheck2.position, -transform.up, checkDistance, ground);
        

        if (isTouchingGround/* || groundcheck2 || groundcheck3*/)
        {
            platformRB.velocity = new Vector2(0, 0);

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundcheck2.position, new Vector3(groundcheck2.position.x, groundcheck2.position.y - checkDistance));
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isTouchingGround)
        {
            platformAnim.SetBool("PlayerTouched", true);

            Invoke("DropPlatform", standingTime);

            Invoke("GetBackUp", standingTime*3);
        }

    }
    


    private void DropPlatform()
    {
        platformRB.velocity = new Vector2(0, -fallingSpeed);

        platformAnim.SetBool("isFalling", true);
        platformAnim.SetBool("PlayerTouched", false);

    }

    private void GetBackUp()
    {
        platformRB.velocity = new Vector2(0, 0);
        platformRB.transform.position = initialPosition;

        platformAnim.SetBool("isFalling", false);
        platformAnim.SetBool("isIdle", true);
    }
}
