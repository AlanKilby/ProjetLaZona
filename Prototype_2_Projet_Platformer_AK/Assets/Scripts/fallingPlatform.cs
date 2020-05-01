using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{

    public Rigidbody2D platformRB;

    // Start is called before the first frame update
    void Start()
    {
        platformRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            Invoke("DropPlatform", 0.5f);
        }
    }
    

    private void DropPlatform()
    {
        platformRB.isKinematic = false;
    }

   
}
