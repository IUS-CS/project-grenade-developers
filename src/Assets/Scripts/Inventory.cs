using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<int> ItemCounters = new List<int>();
    public List<string> ItemNames = new List<string>();
    public List<float> ItemEffectAmounts = new List<float>();
    public float MultiplierBonus = 0.25f;

    public string[] itemTypeList = { "speed_boost", "pick_pocketer", "default" };
    public PlayerController Player;

    //public GameObject[] slots;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

}
