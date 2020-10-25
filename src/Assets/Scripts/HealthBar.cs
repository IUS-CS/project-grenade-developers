using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public PlayerController player;
    public float health;
    public Text healthText;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update ()
    {

        if (player.isPlayerDead == false)
        {

            UpdateHealth();
            healthText.text = "HEALTH: " + health;

        }

        else
        {

            healthText.text = "";

        }

    }

    void UpdateHealth()
    {
        if (health != player.PlayerHealth)
        {
            health = player.PlayerHealth;
        }
    }

}
