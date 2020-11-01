﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float PlayerHealth = 3f; //3 Hearts
    public string PlayerMovementDirection = "RIGHT";
    public float PlayerMovementSpeed = 5f;
    public float PlayerPickUpRadius = 1f;
    public bool isPlayerInjured = false;
    public bool isPlayerDead = false;
    public bool isPlayerWinner = false;
    public bool PlayerFoundPortal = false;
    public bool isPlayerImmortal = false; //God Mode For Testing Purposes

    public float InvulnerabilityCooldown = 4f;
    public float NextAvailableHit = 0f;


    public string CurrentPowerUpEffect = "NOTHING";
    public float CurrentDamageResistence = 0;

    public Inventory PlayerInventory;
    public PlayerAI PlayerMovementScript;
    //public Item[] Items;

    public bool CanPlayerBeHit()
    {

        if (Time.time > NextAvailableHit)
        {
            NextAvailableHit = Time.time + InvulnerabilityCooldown;
            return true;
        }
        return false;
    }

    void DidThePlayerDie()
    {
        if (PlayerHealth == 0 && isPlayerImmortal != true)
        {
            isPlayerDead = true;
        }
    }

    void DidThePlayerWin()
    {
        if (PlayerFoundPortal == true)
        {
            isPlayerWinner = true;
        }
    }

    public void GetEffectsFromInventory()
    {
        //Speed_Boost Index
        if (PlayerInventory.ItemCounters[0] != 0)
        {
            float addAmount = PlayerInventory.ItemEffectAmounts[0];
            PlayerMovementSpeed = PlayerMovementSpeed + addAmount;
        }

        //Pick_Pocketer Index
        if (PlayerInventory.ItemCounters[1] != 0)
        {
            float addAmount = PlayerInventory.ItemEffectAmounts[1];
            PlayerPickUpRadius = PlayerPickUpRadius + addAmount;
        }
    }

    void Start()
    {
        PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        PlayerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAI>();
    }

    void Update()
    {
        DidThePlayerDie();
        DidThePlayerWin();
    }
}
