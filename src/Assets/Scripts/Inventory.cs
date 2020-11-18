using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<int> ItemCounters = new List<int>();
    public List<string> ItemNames = new List<string>();
    public List<float> ItemEffectAmounts = new List<float>();
    public float MultiplierBonus = 0.10f;
    public int NumberOfItems = 6;

    public string[] itemTypeList = { "speed_boost", "pick_pocketer", "health_boost", "multiplier", "damage_resist", "default" };
    public PlayerController Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

}
