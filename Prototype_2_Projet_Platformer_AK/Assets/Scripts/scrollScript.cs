using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollScript : MonoBehaviour
{

    public float scrollSpeed;

    public Vector2 startingPos;

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * -scrollSpeed, 10);
        transform.position = startingPos + Vector2.up * newPos;
    }
}
