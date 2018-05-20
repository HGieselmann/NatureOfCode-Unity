using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using UnityEngine;

public class Example_3_10 : MonoBehaviour
{

	public GameObject Bob;
	public LineRenderer line;
	public Pendulum pendulum;
	
	// Use this for initialization
	void Start () {
		Bob = new GameObject();
		Bob = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		line = gameObject.AddComponent<LineRenderer>();
		line.positionCount = 2;
		line.widthMultiplier = 0.1f;
		pendulum = new Pendulum(new Vector3(16/2, 9, 0), 5f, 45f);
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		pendulum.updateAngle();
		pendulum.updateLocation();
		Bob.transform.position = pendulum.location;
//		print(pendulum.location);
//		print(pendulum.angle);
		line.SetPosition(0, pendulum.origin);
		line.SetPosition(1, pendulum.location);

	}
}


public class Pendulum
{
	public float r; // Length of arm
	public Vector3 origin = new Vector3(); // Orifgin of the pendulum
	public float angle; // Pendulum arm angle
	public float angularVel; // Angular Velocity
	public float angularAcc; // Angular Acceleration
	public float gravity = 1f; // Gravity initialized to 1
	public Vector3 location;

	public Pendulum(Vector3 _origin, float armLength, float _angle)
	{
		r = armLength;
		origin = _origin;
		angle = _angle;

	}

	public void updateAngle()
	{
		angularAcc = (-1 * gravity * Mathf.Sin(angle)) /r;
		angularVel += angularAcc;
		angularVel *= 0.995f; // This accounts for friction, air resistance etc;
		angle += angularVel * Time.deltaTime;
		
	}

	public void updateLocation()
	{
		location = new Vector3(r * Mathf.Sin(angle), r * Mathf.Cos(angle));
		location = origin - location;
		
	}
	
	
}
