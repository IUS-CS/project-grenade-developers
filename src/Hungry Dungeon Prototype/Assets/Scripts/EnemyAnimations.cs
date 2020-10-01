using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator anim;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y > transform.position.y)
        {
            anim.SetBool("isGoingUp", true);
        }
        else
        {
            anim.SetBool("isGoingUp", false);
        }

        if (target.position.x > transform.position.x)
        {
            anim.SetBool("isGoingRight", true);
        }
        else
        {
            anim.SetBool("isGoingRight", false);
        }

        if (target.position.x < transform.position.x)
        {
            anim.SetBool("isGoingLeft", true);
        }
        else
        {
            anim.SetBool("isGoingLeft", false);
        }

        if (target.position.y < transform.position.y)
        {
            anim.SetBool("isGoingDown", true);
        }
        else
        {
            anim.SetBool("isGoingDown", false);
        }
    }
}
