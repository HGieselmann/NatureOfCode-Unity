using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_3_3_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	

	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;
	private Vector3 mousePos;
	private Vector3 dir;

	public Vector3 rotDir;
	
	
	public float topspeed = 1f;
	
	
	

	// Call me Captn Constructor
	public Example_3_3_Mover()
	{
		;
		
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX), UnityEngine.Random.Range(0, CSizeY), 0f);
		velocity = new Vector3(0f, 0f, 0f);
		acceleration = new Vector3( 0, 0, 0);
			
	}

	public void UpdatePosition(Vector3 _mousePos)
	{

		mousePos = _mousePos;
		dir = mousePos - location;
		dir = dir.normalized;
		dir *= 0.1f;
		acceleration = dir;
		
		
		//acceleration = ReturnRandomVector();
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude(velocity, topspeed); // Yes, PVector.limit is more beautiful...
		location += velocity ;

		float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
		rotDir = new Vector3(0, 0, angle);


	}

	public void CheckEdges()
	{
		if (location.x > CSizeX)
		{
			location.x = 0;
		} else if (location.x < 0)
		{
			location.x = CSizeX;
		}

		if (location.y > CSizeY)
		{
			location.y = 0;
		} else if (location.y < 0)
		{
			location.y = CSizeY;
		}
	}


}
