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
    public string[] itemTypeList = { "speed_boost" , "pick_pocketer", "default"};
    public Transform playerPos;
    public PlayerAI player;
    public PlayerController playercontroller;
    private Inventory inventory;

    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAI>();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
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
                case "speed_boost": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Speed_Boost"; inventory.ItemEffectAmounts[index] = (inventory.ItemCounters[index] * inventory.MultiplierBonus);  break;
                case "pick_pocketer": inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Pick_Pocketer"; inventory.ItemEffectAmounts[index] = (inventory.ItemCounters[index] * inventory.MultiplierBonus);  break;
                default: inventory.ItemCounters[index] = inventory.ItemCounters[index] + 1; inventory.ItemNames[index] = "Item: Default"; break;
            }
            playercontroller.GetEffectsFromInventory();
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
