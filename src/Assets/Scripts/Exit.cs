using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    public PlayerController player;
    public Transform playerPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    bool IsPlayerClose()
    {
        if (Vector3.Distance(transform.position, playerPos.position) <= 1.5f)
        {
            return true;
        }

        return false;
    }

    void Update()
    {
        if (player.isPlayerDead != true)
        {
            if (IsPlayerClose() == true && Input.GetKeyDown(KeyCode.E))
            {
                player.PlayerFoundPortal = true;
            }
        }
    }
}