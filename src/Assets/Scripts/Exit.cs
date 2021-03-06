using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            if (IsPlayerClose() == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)))
            {
                player.PlayerFoundPortal = true;
            }
        }
    }
}