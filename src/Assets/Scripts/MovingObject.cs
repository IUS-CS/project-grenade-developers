using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MovingObject : MonoBehaviour
{
    public LayerMask blockingLayer;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidBody;

    public int objectDirectionX;
    public int objectDirectionY;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    protected virtual void Update()
    {

    }
    
    protected bool Move(int x, int y, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;

        Vector2 end = start + new Vector2(x, y);

        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;

        if(hit.transform == null)
        {
            return true;
        }
        return false;
    }

    protected virtual void AttemptMove<T> (int x, int y)
        where T : Component
    {
        RaycastHit2D hit;

        bool canMove = Move(x, y, out hit);

        if (hit.transform == null)
            return;

        T hitComponent = hit.transform.GetComponent<T>();

        if (!canMove && hitComponent != null)
            CantMove(hitComponent);
    }

    protected abstract void CantMove<T> (T component)
        where T : Component;

}