﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour

{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isGoingUp", true);
        }
        else
        {
            anim.SetBool("isGoingUp", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isGoingRight", true);
        }
        else
        {
            anim.SetBool("isGoingRight", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isGoingLeft", true);
        }
        else
        {
            anim.SetBool("isGoingLeft", false);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isGoingDown", true);
        }
        else
        {
            anim.SetBool("isGoingDown", false);
        }
    }
}
