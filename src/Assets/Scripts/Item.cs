using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Sprite itemSprite; //Switches to proper sprite for item 
    public int itemType; //Determine what the item is

    private SpriteRenderer spriteRenderer; //Store component ref to the attached SpriteRenderer


    void Awake()
    {
        //Get component ref to SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
