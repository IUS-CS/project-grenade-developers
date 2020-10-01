using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public float speed;
    public float viewDistance;
    public int damageToPlayer;
    public int health;
    public int aiType;

    private Transform target;


    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!isDead())
        {
            if (Vector2.Distance(transform.position, target.position) < viewDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
        }
    }

    public bool isDead()
    {
        if (this.health <= 0) { return true; }
        else { return false; }
    }

    public void damageTarget()
    {
    }
}
