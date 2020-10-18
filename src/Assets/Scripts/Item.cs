using System.Collections;
using System.Collections.Generic;
//using System.Media;
using System.Security.Cryptography;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    //public Sprite itemSprite; //Switches to proper sprite for item 
    //private SpriteRenderer spriteRenderer; //Store component ref to the attached SpriteRenderer

    public string ItemType; //Determine what the item is
    public string[] itemTypeList = { "speed_boost" , "resurrect" , "undying" , "strength" , "poison", "default"};
    public Transform playerPos;
    public PlayerAI player;
    private Inventory inventory;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAI>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    bool BeingPickedUp()
    {
        if (Vector3.Distance(transform.position, playerPos.position) <= player.pickUpRadius)
        {
            return true;
        }
        return false;
    }

    void Update()
    {
        if (BeingPickedUp() == true)
        {
            int index = Array.IndexOf(itemTypeList, ItemType);
            switch (ItemType)
            {
                case "speed_boost": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Speed_Boost"; break;
                case "resurrect": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Resurrect"; break;
                case "undying": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Undying"; break;
                case "strength": inventory.ItemCounters[index] = inventory.ItemCounters[3] + 1; inventory.ItemNames[3] = "Item: Strength"; break;
                case "poison": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Poison"; break;
                default: inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Default"; break;
            }
            Destroy(gameObject);
            //item.ItemType = "";
        }
    }

/*    void Awake()
    {
        //Get component ref to SpriteRenderer
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }*/
}
