using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezer : MonoBehaviour
{

    public float freezeDuration;
    private float freezeTimeLeft;
    private float timeScaleHolder;

    private bool isFrozen;

    // Update is called once per frame
    void Update()
    {
        if(freezeTimeLeft > 0 && !isFrozen)
        {
            StartCoroutine(DoFreeze());
        }
    }
    public void Freeze()
    {
        freezeTimeLeft = freezeDuration;
    }
    IEnumerator DoFreeze()
    {
        isFrozen = true;
        timeScaleHolder = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(freezeDuration);

        Time.timeScale = timeScaleHolder;
        freezeTimeLeft = 0;
        isFrozen = false;

    }
   
}
