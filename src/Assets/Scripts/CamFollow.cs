using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public bool Toggle = true;
    public float playerCamSize = 4.1f;
    public float gameOverCamSize = 4.1f;
    public float mapCamSize = 57f;
    private Transform Player;
    private Transform GameOverScreen;
    public PlayerController playerController;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        GameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen").transform;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (playerController.isPlayerDead == false) {

            if (Toggle == true)
            {
                mainCamera.orthographicSize = playerCamSize;
                //Camera position stored in temp
                Vector3 temp = transform.position;
                temp.x = Player.position.x;
                temp.y = Player.position.y;
                transform.position = temp;
            }
            else
            {
                transform.position = new Vector3(50, 50, -10);
                mainCamera.orthographicSize = mapCamSize;
            }
        }

        else
        {
            transform.position = new Vector3(-95,96,-10);
            mainCamera.orthographicSize = gameOverCamSize;
        }
    }
}
