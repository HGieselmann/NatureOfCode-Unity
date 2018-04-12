using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;



public class Example_2_7_Mover : MonoBehaviour {
	
	public static int CSizeX = 16;
	public static int CSizeY = 9;
	
	public Vector3 location;
	private Vector3 velocity;
	private Vector3 acceleration;
	public float mass = 1f;
	
	Vector3 f;
	
	// <<<--->>> Constructor <<<--->>>
	public Example_2_7_Mover(float _m, float _initialForce)
	{
		mass = _m;
		location = new Vector3(UnityEngine.Random.Range(0,CSizeX), UnityEngine.Random.Range(0, CSizeY), 0f);
		velocity = new Vector3(0f, 0f, 0f);
		acceleration = new Vector3( 0, _initialForce, 0);
			
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
		} else if (location.x < 0)
		{
			velocity.x *= -1;
			location.x = 0;
		}
	}


}
