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
    public string ItemDescription = "";
    public string[] itemTypeList = { "speed_boost", "pick_pocketer", "health_boost", "multiplier", "default" };
    //public Item[] ITEMS;
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
        if (BeingPickedUp() == true && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            string AddedItem = "";
            int index = Array.IndexOf(itemTypeList, ItemType);
            switch (ItemType)
            {
                case "speed_boost": AddedItem = "speed_boost"; inventory.ItemCounters[0] = inventory.ItemCounters[0] + 1; inventory.ItemNames[0] = "Item: Speed_Boost"; inventory.ItemEffectAmounts[0] = (inventory.ItemCounters[0] * inventory.MultiplierBonus); break;
                case "pick_pocketer": AddedItem = "pick_pocketer"; inventory.ItemCounters[1] = inventory.ItemCounters[1] + 1; inventory.ItemNames[1] = "Item: Pick_Pocketer"; inventory.ItemEffectAmounts[1] = (inventory.ItemCounters[1] * inventory.MultiplierBonus); break;
                case "health_boost": AddedItem = "health_boost"; inventory.ItemCounters[2] = inventory.ItemCounters[2] + 1; inventory.ItemNames[2] = "Item: Health_Boost"; break;
                case "multiplier": AddedItem = "multiplier"; inventory.ItemCounters[3] = inventory.ItemCounters[3] + 1; inventory.ItemNames[3] = "Item: Multiplier"; break;
                default: inventory.ItemCounters[4] = inventory.ItemCounters[4] + 1; inventory.ItemNames[4] = "Item: Default"; break;
            }
            playercontroller.GetEffectsFromInventory(AddedItem);
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
