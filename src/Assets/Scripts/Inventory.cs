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

    public int Global_Stack = 10;

    public int SB_Stack = 0;
    public int PP_Stack = 0;
    public int HB_Stack = 0;
    public int MB_Stack = 0;
    public int DR_Stack = 0;
    public int CW_Stack = 0;

    public string[] itemTypeList = { "speed_boost", "pick_pocketer", "health_boost", "multiplier", "damage_resist", "cam_wide" };
    public PlayerController Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

    }

}
