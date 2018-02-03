using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 300f;
	public float floorDistance;

	private Rigidbody2D rb2d;

	private bool grounded = false;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		float hor = Input.GetAxisRaw ("Horizontal");
		Debug.Log (Mathf.Abs (rb2d.velocity.x));
		if (Mathf.Abs (rb2d.velocity.x) < maxSpeed)
		{
			rb2d.AddForce (new Vector2 (hor * moveForce, 0f));
		}

	}
}
