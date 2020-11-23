using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float PlayerHealth = 6f; //Technically 3 But Each is Worth 1/2
    public float PlayerMaxHealth = 6f;
    public string PlayerMovementDirection = "RIGHT";
    public float PlayerMovementSpeed = 5f;
    public float PlayerPickUpRadius = 1f;
    public bool isPlayerInjured = false;
    public bool isPlayerDead = false;
    public bool isPlayerWinner = false;
    public bool PlayerFoundPortal = false;
    public bool isPlayerImmortal = false; //God Mode For Testing Purposes

    public float InvulnerabilityCooldown = 4f;
    public float NextAvailableHit = 0f;


    public string CurrentPowerUpEffect = "NOTHING";
    public float CurrentDamageResistence = 0;

    public Inventory PlayerInventory;
    public PlayerAI PlayerMovementScript;
    //public Item[] Items;

    public Text WinOrLose;
    public Text Compass;

    public Transform Exit;

    public CamFollow playerCam;

    public bool StopMovementIfDeadOrWon()
    {
        if (isPlayerDead == true || isPlayerWinner == true)
        {
            return true;
        }
        return false;
    }

    public bool CanPlayerBeHit()
    {

        if (Time.time > NextAvailableHit)
        {
            NextAvailableHit = Time.time + InvulnerabilityCooldown;
            return true;
        }
        return false;
    }

    public bool DidThePlayerDie()
    {
        if (PlayerHealth == 0 && isPlayerImmortal != true)
        {
            isPlayerDead = true;
            WinOrLose.text = "You Died...\nPress Escape";
            return true;
        }
        return false;
    }

    public bool DidThePlayerWin()
    {
        if (PlayerFoundPortal == true)
        {
            isPlayerWinner = true;
            WinOrLose.text = "You Won!!!\nPress Escape";
            return true;
        }

        return false;
    }

    public void GetEffectsFromInventory(string PreviouslyAddedItem)
    {
        //Speed_Boost Index
        if (PlayerInventory.ItemCounters[0] != 0 && PreviouslyAddedItem == "speed_boost")
        {
            float addAmount = PlayerInventory.ItemEffectAmounts[0];
            PlayerMovementSpeed = PlayerMovementSpeed + addAmount;
        }

        //Pick_Pocketer Index
        if (PlayerInventory.ItemCounters[1] != 0 && PreviouslyAddedItem == "pick_pocketer")
        {
            float addAmount = PlayerInventory.ItemEffectAmounts[1];
            PlayerPickUpRadius = PlayerPickUpRadius + addAmount;
        }

        //Health Boost Index
        if (PlayerInventory.ItemCounters[2] != 0 && PreviouslyAddedItem == "health_boost")
        {
            if (PlayerHealth < PlayerMaxHealth)
            {
                PlayerHealth = PlayerHealth + (1 + PlayerInventory.ItemCounters[3]); //For each Multiplier Bonus you have you gain an extra heart from this item.
            }
        }

        //Multiplier Index
        if (PlayerInventory.ItemCounters[3] != 0 && PreviouslyAddedItem == "multiplier")
        {
            float addAmount = 0.01f;
            PlayerInventory.MultiplierBonus = PlayerInventory.MultiplierBonus + addAmount;
        }

        //Damage Resist
        if (PlayerInventory.ItemCounters[4] != 0 && PreviouslyAddedItem == "damage_resist")
        {
            float addAmount = 0.01f;
            InvulnerabilityCooldown = InvulnerabilityCooldown + addAmount;
        }

        //Camera Extender 
        if (PlayerInventory.ItemCounters[5] != 0 && PreviouslyAddedItem == "cam_wide")
        {
            float addAmount = 0.25f;
            playerCam.playerCamSize = playerCam.playerCamSize + addAmount;
        }
        //Default Doesnt Do Anything, Just For Testing
    }

    void Start()
    {
        PlayerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        PlayerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAI>();
        Exit = GameObject.FindGameObjectWithTag("Exit").GetComponent<Transform>();
    }

    void Update()
    {
        DidThePlayerDie();
        DidThePlayerWin();
        PrintLocations();
    }

    void PrintLocations()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Compass.text = "Your Position: [" + (int)transform.position.x + "] [" + (int)transform.position.y + "] \n" +
                              "Exit Position  [" + (int)Exit.transform.position.x + "] [" + (int)Exit.transform.position.y + "]";
            return;
        }

        Compass.text = "";
    }
}
