using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaker : MonoBehaviour
{
    Transform target;
    Vector3 initialPos;

    public float duration;

    float pendingShakeDuration;

    bool isShaking;

    [Range(0,2)]
    public float Intensity;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponent<Transform>();
        initialPos = target.localPosition;
    }

    public void Shake()
    {
        if (duration > 0)
        {
            pendingShakeDuration += duration;
        }
    }

    void Update()
    {
        if(pendingShakeDuration > 0 && !isShaking)
        {
            StartCoroutine(DoShake());
        }    
    }

    IEnumerator DoShake()
    {
        isShaking = true;

        var startTime = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < startTime + pendingShakeDuration)
        {
            var randomPoint = new Vector3((target.localPosition.x + Random.Range(-1, 1) * Random.Range(-Intensity, Intensity)), (target.localPosition.y + Random.Range(-1, 1) * Random.Range(-Intensity,Intensity)), initialPos.z);
            target.localPosition = randomPoint;
            yield return null;
        }

        pendingShakeDuration = 0;
        target.localPosition = initialPos;
        isShaking = false;
    }
}    
