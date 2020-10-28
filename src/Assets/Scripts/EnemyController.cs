using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] EnemyTypes;
    public int EnemyHealth = 1;
    public float EnemyMovementSpeed = 1.5f;
    public float EnemyDamageOnTarget = 0.5f;
    public float EnemyHitCooldown = 4f;
    private float EnemyNextHit = 0f;
    public float EnemyViewRadius = 10f;
    public float EnemyHitRadius = 0.5f;
    public bool isEnemyDead = false;

    public EnemyAI Enemy;
    public PlayerController Player;
    public Transform PlayerPosition;

    void DidThisEnemyDie()
    {
        if (isEnemyDead == true || EnemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    bool IsCloseToThePlayer()
    {
        if (Vector3.Distance(transform.position, PlayerPosition.position) <= EnemyHitRadius)
        {
            return true;
        }

        return false;
    }

    public void DealDamageToPlayer()
    {
        if (IsCloseToThePlayer() == true)
        {

            if (Time.time > EnemyNextHit) {

                if (Player.PlayerHealth != 0 && Player.isPlayerDead != true)
                {
                    Player.PlayerHealth -= (EnemyDamageOnTarget - Player.CurrentDamageResistence);
                    EnemyNextHit = Time.time + EnemyHitCooldown;
                }
            }
        }

        if (KilledThePlayer() == true)
        {
            DestroySelf();
        }
    }

    public bool KilledThePlayer()
    {
        if (Player.isPlayerDead == true)
        {
            return true;
        }
        return false;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyAI>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {

        //Checks To See If The Enemy Is Dead Or Alive
        DidThisEnemyDie();
        DealDamageToPlayer();


    }
}
