using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Example_2_2_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	
	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;
	private float mass;
	
	Vector3 f;
	
	// Call me Captn Constructor
	public Example_2_2_Mover(float m, float x, float y)
	{
		mass = m;
		location = new Vector3(x, y, 0f);
		velocity = new Vector3(0f, 0f, 0f);
		acceleration = new Vector3( 0, 0, 0);
			
	}

	public void applyForce(Vector3 force)
	{
		f = force /  mass;
		acceleration += f;
	}

	public void UpdatePosition(	)
	{
		velocity += acceleration * Time.deltaTime;
		location += velocity ;
		acceleration *= 0f;
	}

	public void CheckEdges()
	{
		if (location.y > CSizeY)
		{
			velocity.y *= -1;
			location.y = CSizeY;
		} else if (location.y < 0)
		{
			velocity.y *= -1;
			location.y = 0;
		}

		if (location.x > CSizeX)
		{
			velocity.x *= -1;
			location.x = CSizeX;
		}
	}


}
