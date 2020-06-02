using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    public Animator transitionsAnim;

    // Start is called before the first frame update
    void Start()
    {

        Invoke("Transition", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Transition()
    {
        transitionsAnim.SetTrigger("start");

    }
}
