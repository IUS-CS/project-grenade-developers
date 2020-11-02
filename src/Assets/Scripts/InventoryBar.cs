using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{


    public Inventory inventory;
    public Text inventoryText;
    public PlayerController player;

    public List<int> counters;
    public List<string> names;
    public List<float> effects;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        counters = inventory.ItemCounters;
        names = inventory.ItemNames;
        effects = inventory.ItemEffectAmounts;
    }

    void Update()
    {
        if (player.isPlayerDead == false && player.isPlayerWinner == false)
        {

            checkInventory();
            printInventory();

        }

        else
        {

            inventoryText.text = "";

        }
    }

    void checkInventory()
    {
        if (counters != inventory.ItemCounters)
        {
            counters = inventory.ItemCounters;
        }
        if (names != inventory.ItemNames)
        {
            names = inventory.ItemNames;
        }
        if (effects != inventory.ItemEffectAmounts)
        {
            effects = inventory.ItemEffectAmounts;
        }
    }

    void printInventory()
    {
        inventoryText.text = "INVENTORY: " +
                        "\n[0]: " + inventory.ItemCounters[0] + " : " + inventory.ItemNames[0] + " : " + inventory.ItemEffectAmounts[0] +
                        "\n[1]: " + inventory.ItemCounters[1] + " : " + inventory.ItemNames[1] + " : " + inventory.ItemEffectAmounts[1] +
                        "\n[2]: " + inventory.ItemCounters[2] + " : " + inventory.ItemNames[2] + " : " + inventory.ItemEffectAmounts[2];
    }

}
