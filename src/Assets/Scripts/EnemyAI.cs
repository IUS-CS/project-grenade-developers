using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MovingObject
{
    public float moveSpeed = 1.5f;
    public Transform movePoint;
    public float viewDistance = 10f;

    public LayerMask whatStopsMovement;

    private Transform target;

    public override void Start() {
        movePoint.parent = null;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public override void Update() {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        

        if(Vector3.Distance(transform.position,movePoint.position) <= .05f && Vector3.Distance(transform.position,target.position) <= viewDistance)
        {
            if(Mathf.Abs(transform.position.x - target.position.x) > Mathf.Abs(transform.position.y - target.position.y))
            {
                if(transform.position.x > target.position.x) 
                {
                    if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(-1f, 0f, 0f)), .2f, whatStopsMovement)) {
                        movePoint.position += new Vector3(-1f, 0f, 0f);
                    }
                }
                else
                {
                    if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(1f, 0f, 0f)), .2f, whatStopsMovement)) {
                        movePoint.position += new Vector3(1f, 0f, 0f);
                    }
                }
            } 
            else
            {
                if(transform.position.y > target.position.y) 
                {
                    if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(0f, -1f, 0f)), .2f, whatStopsMovement)) {
                        movePoint.position += new Vector3(0f, -1f, 0f);
                    }
                }
                else
                {
                    if (!Physics2D.OverlapCircle((movePoint.position + new Vector3(0f, 1f, 0f)), .2f, whatStopsMovement)) {
                        movePoint.position += new Vector3(0f, 1f, 0f);
                    }
                }
            }
            

        }
    }

}
