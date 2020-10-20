﻿
using System;
using System.Collections;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{

    public float moveSpeed = 8f;
    public Transform movePoint;
    public float pickUpRadius = 1f;

    public LayerMask whatStopsMovement;

    void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }
}