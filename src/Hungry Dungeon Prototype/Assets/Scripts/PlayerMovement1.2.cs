using System.Collections;
using System.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float restartLevelDelay = 1f;

	private Animator animator;


	// Use this for initialization
	private override void Start () 
	{
		animator = GetComponent<Animator> ();
		base.Start();
	}
		
	// Update is called once per frame
	private void Update () 
	{
		int horizontal = 0;
		int vertical = 0;

		horizontal = (int)(Input.GetAxisRaw ("Horizontal"));

		vertical = (int)(Input.GetAxisRaw ("Vertical"));

		if (horizontal != 0) 
		{
			vertical = 0;
		}

		if (horizontal != 0 || vertical != 0) 
		{
			AttemptMove<Wall> (horizontal, vertical);
		}
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);

		CheckIfGameOver ();
	}

	protected override void OnCantMove <T> (Time component)
	{
		Wall hitWall = component as Wall;
	}

	private void Restart ()
	{
		SceneManager.LoadScene (0);
	}
}
