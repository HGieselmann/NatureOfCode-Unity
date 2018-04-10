using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class Example_2_1_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	
	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;
	private float mass = 1f;
	
	Vector3 f;
	
	// Call me Captn Constructor
	public Example_2_1_Mover()
	{
		
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX/4), UnityEngine.Random.Range(0, CSizeY), 0f);
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
		//acceleration = ReturnRandomVector();
		velocity += acceleration * Time.deltaTime;
		//Debug.Log(velocity);
		location += velocity ;
		acceleration *= 0f;
	}

	public static Vector3 ReturnRandomVector()
	{
		//returns a normalized random Vector
		Vector3 randV =  new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f),UnityEngine.Random.Range(-1f, 1f));
		return randV.normalized;

	}

	public void CheckEdges()
	{
//		if (location.x > CSizeX)
//		{
//			location.x = 0;
//		} else if (location.x < 0)
//		{
//			location.x = CSizeX;
//		}
//
//		if (location.y > CSizeY)
//		{
//			location.y = 0;
//		} else if (location.y < 0)
//		{
//			location.y = CSizeY;
//		}

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
