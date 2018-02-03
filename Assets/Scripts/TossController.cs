using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TossController : MonoBehaviour
{
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void toss (Vector2 direction, float tossForce)
	{
		rb2d = GetComponent<Rigidbody2D> ();
		direction.Normalize ();
		rb2d.AddForce (direction * tossForce);
		Debug.Log (tossForce);
	}
}
