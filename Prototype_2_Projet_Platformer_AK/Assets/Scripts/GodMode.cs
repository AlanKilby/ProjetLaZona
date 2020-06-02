using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodMode : MonoBehaviour
{

    public GameObject player;

    public Vector3 clickPosition;


    private void Start()
    {
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(ScoreStore.godMode);

        if (Input.GetKeyDown("f1") && !ScoreStore.godMode)
        {
            ScoreStore.godMode = true;
        }

        else if (Input.GetKeyDown("f1") && ScoreStore.godMode)
        {
            ScoreStore.godMode = false;
        }
        

        if (Input.GetMouseButtonDown(0) && ScoreStore.godMode)
        {
            Debug.Log(Input.mousePosition);

            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,2));
            player.transform.position = new Vector3(clickPosition.x, clickPosition.y, 0);
        }
    }
}
