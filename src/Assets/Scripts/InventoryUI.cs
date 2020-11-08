using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public int NumberOfExistingItems;

    public Image[] InventorySlots;
    public Sprite speedBoost;
    public Sprite pickPocket;
    public Sprite defaultItem;

    public bool SBINST;
    public bool PPINST;
    public bool DFINST;

    public GameObject speedBoostButton;
    public GameObject pickPocketButton;
    public GameObject defaultItemButton;

    public Inventory inventory;

    public List<int> counters;
    public List<string> names;
    public List<float> effects;

    public PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        counters = inventory.ItemCounters;
        names = inventory.ItemNames;
        effects = inventory.ItemEffectAmounts;
    }

    bool checkInventory()
    {
        if (counters != inventory.ItemCounters)
        {
            counters = inventory.ItemCounters;
            return true;
        }
        if (names != inventory.ItemNames)
        {
            names = inventory.ItemNames;
            return true;
        }
        if (effects != inventory.ItemEffectAmounts)
        {
            effects = inventory.ItemEffectAmounts;
            return true;
        }
        return false;
    }

    void printInventory()
    {
        if (counters[0] > 0 && SBINST != true) //Has A Speed Boost
        {
            Instantiate(speedBoostButton, InventorySlots[0].transform, false);
            SBINST = true;
        }
        if (counters[1] > 0 && PPINST != true) //Has A PickPocket
        {
            Instantiate(pickPocketButton, InventorySlots[1].transform, false);
            PPINST = true;
        }
        if (counters[2] > 0 && DFINST != true) //Has A Default Item
        {
            Instantiate(defaultItemButton, InventorySlots[2].transform, false);
            DFINST = true;
        }
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
            for (int x = 0; x < InventorySlots.Length; x++)
            {
                InventorySlots[x].enabled = false;
            }
        }
    }
}
