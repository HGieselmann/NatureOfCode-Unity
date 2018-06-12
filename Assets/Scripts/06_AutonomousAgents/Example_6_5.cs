/*using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Vuforia;

public class Example_6_5 : MonoBehaviour
{

	public Vehicle_6_5 Vehicle_6_5;

	// Use this for initialization
	void Start () {
		Vehicle_6_5 = new Vehicle_6_5(8, 4.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		Vehicle_6_5.update();
		Vehicle_6_5.seek();
		Vehicle_6_5.display();
		Vehicle_6_5.CheckEdges();
	}
}

public class Vehicle_6_5
{
	public Vector3 location;
	Vector3 velocity;
	Vector3 acceleration;
	float r;
	float maxforce;
	float maxspeed;
	public GameObject vehicle61;
	public GameObject debugsphere;
	public GameObject debugsphere2;
 
	public Vehicle_6_5(float _x, float _y) {
		acceleration = new Vector3(0,0,0);
		velocity = new Vector3(0,0,0);
		location = new Vector3(_x, _y,0);
		r = 3.0f;
		maxspeed = 3f;
		maxforce = 0.1f;
		debugsphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		debugsphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		debugsphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		debugsphere2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		vehicle61 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		vehicle61.transform.localScale= new Vector3(.2f, .2f, .4f);
	}
 
	public void update() {
		velocity += acceleration;
		velocity = CS.ConstrainVector3(velocity, maxspeed);
		location += velocity * Time.deltaTime;
		acceleration *= 0;
	}
 
	public void applyForce(Vector3 force)
	{
		acceleration += force; // Inverse for fleeing behaviour
	}
 
	
	public void seek(Vector3 target)
	{
		Vector3 desired = target - location;
		desired = desired.normalized;
		desired *= maxspeed;
		
		
		
		// Wall ""bouncing""
		if (location.x < 0.5f)
		{
			desired.x += 2;
		} else if (location.x > 15.5f)
		{
			desired.x -= 2;
		}

		if (location.y < 0.5f)
		{
			desired.y += 2;
		}else if (location.y > 8.5f)
		{
			desired.y -= 2;
		}
		Vector3 steer = desired - velocity;
		steer = CS.ConstrainVector3(steer, maxforce);
		applyForce(steer);
		
		
	}

	public Vector3 wander()
	{
		
		Vector3 circleCenter = location + velocity.normalized * 1;
		debugsphere.transform.position = circleCenter;
		float x = Mathf.Cos(Random.Range(0, 360));
		float y = Mathf.Sin(Random.Range(0, 360));
		Vector3 aim = new Vector3(circleCenter.x + x, circleCenter.y + y);
		debugsphere2.transform.position = aim;
		return aim;

	}
 
	public void display()
	{
		
		vehicle61.transform.position = new Vector3(location.x, location.y, 0); // constrained Z
		var newRotation = Quaternion.LookRotation(velocity).eulerAngles;  // 
		newRotation.z = 0; // Constrain Rotation
		vehicle61.transform.rotation = Quaternion.Euler(newRotation);


	}

	public void CheckEdges()
	{
		if (location.x < 0)
		{
			location.x = 16;
		} else if (location.x > 16)
		{
			location.x = 0;
		}

		if (location.y < 0)
		{
			location.y = 9;
		}else if (location.y > 9)
		{
			location.y = 0;
		}
	}
}

public class FollowPath_6_5
{
	private LineRenderer line;
	public Vector3 start;
	public Vector3 end;

	public float radius;
	
	public FollowPath_6_5()
	{
		radius = .5f;
		line = new LineRenderer();
		line.widthMultiplier = radius;
		
		start = new Vector3(0, 6, 0);
		end = new Vector3(16, 2, 0);

	}

	public void displayPath()
	{
		line.SetPosition(0, start);
		line.SetPosition(1, end);
	}
}*/