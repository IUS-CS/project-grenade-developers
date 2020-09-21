using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private Animator animator;
	private Transform target;
	private bool skipMove;

	// Use this for initialization
	protected override void Start () 
	{
		GameManager.instance.AddEnemyToList (this);
		animator = GetComponent<Animator> ();

		target = GameObject.FindGameObjectWithTag ("Player").transform;
		base.Start ();
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		base.AttemptMove <T> (xDir, yDir);
		skipMove = true;
	}

	public void MoveEnemy()
	{
		int xDir = 0;
		int yDir = 0;

		if (Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
			yDir = target.position.y > transform.position.y ? 1 : -1;
		else
			xDir = target.position.x > transform.position.x ? 1 : -1;
		AttemptMove <PlayerMovement> (xDir, yDir);
	}

	protected override void OnCantMove <T> (T component)
	{
		PlayerMovement hitPlayer = component as PlayerMovement;
	}
	// Update is called once per frame

}
