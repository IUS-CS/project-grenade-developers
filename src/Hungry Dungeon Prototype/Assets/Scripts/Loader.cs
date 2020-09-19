using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject gameManager;      //GameManager prefab to instant
    
    void Awake()
    {
        if (GameManager.instance == null)
            Instantiate(gameManager);
    }
}
