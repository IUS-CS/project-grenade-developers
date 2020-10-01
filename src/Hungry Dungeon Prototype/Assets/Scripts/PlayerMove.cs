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
    


    void Update()
    {
        if (!isDead())
        {
            var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.position += move * speed * Time.deltaTime;
        }
    }

    public bool isDead()
    {
        if (this.health <= 0) { return true; }
        else { return false; }
    }
}
