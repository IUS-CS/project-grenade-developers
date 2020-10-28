
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    public float moveSpeed;
    public float pickUpRadius;

    public Transform movePoint;
    public string Direction; //Can Be RIGHT, LEFT, UP, DOWN
    public LayerMask whatStopsMovement;

    public PlayerController player;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        moveSpeed = player.PlayerMovementSpeed;
        pickUpRadius = player.PlayerPickUpRadius;
        Direction = player.PlayerMovementDirection;
        movePoint.parent = null;
    }

    void CheckInput()
    {
        if (Input.GetAxisRaw("Horizontal") == 1f)
        {
            Direction = "RIGHT";
        }
        if (Input.GetAxisRaw("Horizontal") == -1f)
        {
            Direction = "LEFT";
        }
        if (Input.GetAxisRaw("Vertical") == 1f)
        {
            Direction = "UP";
        }
        if (Input.GetAxisRaw("Vertical") == -1f)
        {
            Direction = "DOWN";
        }
    }

    void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {

            if (Direction == "UP")
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(0f, 1f, 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, 1f, 0f);
                }
            }

            if (Direction == "DOWN")
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(0f, -1f, 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, -1f, 0f);
                }
            }

            if (Direction == "RIGHT")
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(1f, 0f, 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(1f, 0f, 0f);
                }
            }

            if (Direction == "LEFT")
            {
                if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(-1f, 0f, 0f)), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(-1f, 0f, 0f);
                }
            }
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isPlayerDead == false)
        {
            CheckInput();
            Move();

            if (moveSpeed != player.PlayerMovementSpeed)
            {
                moveSpeed = player.PlayerMovementSpeed;
            }

            if (pickUpRadius != player.PlayerPickUpRadius)
            {
                pickUpRadius = player.PlayerPickUpRadius;
            }
        }
    }
}