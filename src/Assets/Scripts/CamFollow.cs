using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;  
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Camera position stored in temp
        Vector3 temp = transform.position;
        temp.x = Player.position.x;
        temp.y = Player.position.y;
        transform.position = temp;
    }
}
