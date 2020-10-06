
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAI : MovingObject
{

    protected override void Update()
    {        
        int horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        int vertical = (int)(Input.GetAxisRaw("Vertical"));


        

        if(horizontal == 1)
        {
            objectDirectionX = 1;
            objectDirectionY = 0;
        }
        if(horizontal == -1)
        {
            objectDirectionX = -1;
            objectDirectionY = 0;
        }
        if(vertical == 1)
        {
            objectDirectionX = 0;
            objectDirectionY = 1;
        }
        if(vertical == -1)
        {
            objectDirectionX = 0;
            objectDirectionY = -1;
        }

        AttemptMove<Wall>(objectDirectionX, objectDirectionY);


        Vector2 velocity = new Vector2(objectDirectionX, objectDirectionY);

        //rigidBody.velocity = new Vector2(objectDirectionX * transform.localScale.x * 2, objectDirectionY * transform.localScale.y * 2);
        print(rigidBody.position);

        ///////////////////////THIS IS F***ING WRONG////////////////////////////
        int milliseconds = 50;
        Thread.Sleep(milliseconds);
        ///////////////////////THIS IS F***ING WRONG////////////////////////////

        rigidBody.MovePosition(rigidBody.position + velocity);
        

    }




    protected override void CantMove <T> (T component)
    {
        Wall hitWall = component as Wall;
        objectDirectionX = 0;
        objectDirectionY = 0;
    }
}