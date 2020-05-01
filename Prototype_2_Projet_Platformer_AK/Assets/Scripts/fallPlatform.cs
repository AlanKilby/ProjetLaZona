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

    void Start()
    {
        platformRB = GetComponent<Rigidbody2D>();
        platformRB.gravityScale = 0;
    }
    private void Update()
    {
        //Physics2D.Raycast(groundcheck1.position,-transform.up, checkDistance,ground);
        //Physics2D.Raycast(groundcheck3.position, -transform.up, checkDistance, ground);
        //Physics2D.OverlapCircle(groundcheck2.position, checkDistance, ground);
        isTouchingGround = Physics2D.Raycast(groundcheck2.position, -transform.up, checkDistance, ground);
        

        if (isTouchingGround/* || groundcheck2 || groundcheck3*/)
        {
            platformRB.velocity = new Vector2(0, 0);

        }

    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine(groundcheck1.position, new Vector3(groundcheck1.position.x, groundcheck1.position.y - checkDistance));
        Gizmos.DrawLine(groundcheck2.position, new Vector3(groundcheck2.position.x, groundcheck2.position.y - checkDistance));
        //Gizmos.DrawLine(groundcheck3.position, new Vector3(groundcheck3.position.x, groundcheck1.position.y - checkDistance));
        //Gizmos.DrawWireSphere(groundcheck2.position, checkDistance);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !isTouchingGround)
        {
            Invoke("DropPlatform", standingTime);
        }

    }
    


    private void DropPlatform()
    {
        platformRB.velocity = new Vector2(0, -fallingSpeed);

    }
}
