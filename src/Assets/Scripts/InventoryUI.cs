using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public int NumberOfExistingItems;

    public Image[] InventorySlots;
    public Text InventoryCount0;
    public Text InventoryCount1;
    public Text InventoryCount2;
    public Text InventoryCount3;
    public Text InventoryCount4;
    public Text InventoryCount5;
    public Sprite speedBoost;
    public Sprite pickPocket;
    public Sprite defaultItem;
    public Sprite healthBoost;
    public Sprite multiplier;
    public Sprite damageResist;

    public bool SBINST;
    public bool PPINST;
    public bool DFINST;
    public bool HBINST;
    public bool MINST;
    public bool DRINST;

    public GameObject speedBoostButton;
    public GameObject pickPocketButton;
    public GameObject defaultItemButton;
    public GameObject healthBoostButton;
    public GameObject multiplierButton;
    public GameObject damageResistButton;

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
        if (counters[0] > 0) //Has A Speed Boost
        {
            if (SBINST != true)
            {
                Instantiate(speedBoostButton, InventorySlots[0].transform, false);
                SBINST = true;
            }
        }

        if (counters[1] > 0) //Has A PickPocket
        {
            if (PPINST != true)
            {
                Instantiate(pickPocketButton, InventorySlots[1].transform, false);
                PPINST = true;
            }
        }

        if (counters[2] > 0) //Has A Health Item
        {
            if (HBINST != true)
            {
                Instantiate(healthBoostButton, InventorySlots[2].transform, false);
                HBINST = true;
            }
        }

        if (counters[3] > 0) //Has Multiplier Item
        {
            if (MINST != true)
            {
                Instantiate(multiplierButton, InventorySlots[3].transform, false);
                MINST = true;
            }
        }

        if (counters[4] > 0) //Has Damage_Resist Item
        {
            if (DRINST != true)
            {
                Instantiate(damageResistButton, InventorySlots[4].transform, false);
                DRINST = true;
            }
        }

        if (counters[5] > 0) //Has Default Item
        {
            if (DFINST != true)
            {
                Instantiate(defaultItemButton, InventorySlots[5].transform, false);
                DFINST = true;
            }
        }

        InventoryCount0.text = "" + (counters[0]);
        InventoryCount1.text = "" + (counters[1]);
        InventoryCount2.text = "" + (counters[2]);
        InventoryCount3.text = "" + (counters[3]);
        InventoryCount4.text = "" + (counters[4]);
        InventoryCount5.text = "" + (counters[5]);
    }

    void Update()
    {

        checkInventory();
        printInventory();

    }
}
