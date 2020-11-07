using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float health = 6;
    public int numOfHearts = 6;

    public Image[] hearts;
    public Sprite heart;
    public Sprite corruptHeart;

    public PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        health = player.PlayerHealth;
    }

    void Update()
    {

        if (player.isPlayerDead == false && player.isPlayerWinner == false)
        {

            health = player.PlayerHealth;

            if (health > numOfHearts)
            {
                health = numOfHearts;
            }

            for (int x = 0; x < hearts.Length; x++)
            {
                if (x < health)
                {
                    hearts[x].sprite = heart;
                }
                else
                {
                    hearts[x].sprite = corruptHeart;
                }

                if (x < numOfHearts)
                {
                    hearts[x].enabled = true;
                }
                else
                {
                    hearts[x].enabled = false;
                }
            }

        }

        else
        {
            TurnOffHearts();
        }
    }

    void TurnOffHearts()
    {
        for (int x = 0; x < hearts.Length; x++)
        {
            hearts[x].enabled = false;
        }
    }
}
