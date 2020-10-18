using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using UnityEngine;

public class PickUp : MonoBehaviour
{

/*    private Inventory inventory;
    public Transform player;
    public Item item;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        item = GameObject.FindGameObjectWithTag("Item").GetComponent<Item>();
    }

    bool BeingPickedUp()
    {
        if (Vector3.Distance(transform.position, player.position) <= .15f)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (BeingPickedUp() == true)
        {
            string type = item.ItemType;
            switch(type)
            {
                case "speed_boost": inventory.ItemCounters[0] = inventory.ItemCounters[0] + 1; inventory.ItemNames[0] = "Item: Speed_Boost"; break;
                case "resurrect": inventory.ItemCounters[1] = inventory.ItemCounters[1] + 1; inventory.ItemNames[1] = "Item: Resurrect"; break;
                case "undying": inventory.ItemCounters[2] = inventory.ItemCounters[2] + 1; inventory.ItemNames[2] = "Item: Undying"; break;
                case "strength": inventory.ItemCounters[3] = inventory.ItemCounters[3] + 1; inventory.ItemNames[3] = "Item: Strength"; break;
                case "poison": inventory.ItemCounters[4] = inventory.ItemCounters[4] + 1; inventory.ItemNames[4] = "Item: Poison"; break;
                default: inventory.ItemCounters[6] = inventory.ItemCounters[6] + 1; inventory.ItemNames[6] = "Item: Default"; break;
            }
            Destroy(gameObject);
            item.ItemType = "";
        }
    }*/
}
