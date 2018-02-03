using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTossController : MonoBehaviour
{
	public GameObject orangePrefab;
	public Vector2 orangeSpawnPoint = new Vector3 (1f, 0f);
	public float maxTossForce = 99f;
	public int tossModifier = 0;

	private bool holding = false;
	private float holdTime = 0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame

	void LateUpdate ()
	{
				
	}

	void FixedUpdate ()
	{
		bool mousePressed = Input.GetMouseButton (0);
		if (mousePressed && !holding)
		{
			Debug.Log ("Holding");
			holding = true;
			startHolding ();
		}
		else if (!mousePressed && holding)
			{
				Debug.Log ("Released");
				holding = false;
				stopHolding ();
			}
	}

	private void startHolding ()
	{
		//TODO: Animate that we are holding an orange, ready to throw.
		holdTime = Time.realtimeSinceStartup;
	}

	private void stopHolding ()
	{
		//TODO: Animate toss
		//TODO: Spawn orange
		Vector2 spawnPoint = transform.position;
		spawnPoint += orangeSpawnPoint;
		GameObject orange = Instantiate (orangePrefab, transform.position, Quaternion.identity);
		TossController orangeTossController = orange.GetComponent<TossController> ();
		//TODO: Get mouse location
		Vector2 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//TODO: Get toss force
		float holdingTime = Mathf.Clamp (Time.realtimeSinceStartup - holdTime, 1f, 3f);
		//TODO: Toss.
		orangeTossController.toss (mousePosition - (Vector2)transform.position, maxTossForce * (holdingTime + tossModifier) / 3);
	}
}
