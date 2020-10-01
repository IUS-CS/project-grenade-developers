using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // Update is called once per frame
    public int health;
    public float speed;
    public string currentPowerEffect;
    //Powerup Effects Tests
    //Speed, Strength

    public Vector3 move = new Vector3(1, 0, 0);

    void Update()
    {
        if (!isDead())
        {
            
            if(Input.GetKey(KeyCode.RightArrow))
            {
                move = new Vector3(1, 0, 0);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                move = new Vector3(-1, 0, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                move = new Vector3(0, 1, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                move = new Vector3(0, -1, 0);
            }

            //var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
    }

    public bool isDead()
    {
        if (this.health <= 0) { return true; }
        else { return false; }
    }
}
