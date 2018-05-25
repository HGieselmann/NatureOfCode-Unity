using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_6_2 : MonoBehaviour
{

	public Vehicle_6_2 Vehicle_6_2;

	// Use this for initialization
	void Start () {
		Vehicle_6_2 = new Vehicle_6_2(8, 4.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vehicle_6_2.update();
		Vehicle_6_2.arrive(CS.MousePositionfromCam());
		Vehicle_6_2.display();
	}
}

public class Vehicle_6_2
{
	Vector3 location;
	Vector3 velocity;
	Vector3 acceleration;
	float r;
	float maxforce;
	float maxspeed;
	public GameObject vehicle61;
 
	public Vehicle_6_2(float _x, float _y) {
		acceleration = new Vector3(0,0,0);
		velocity = new Vector3(0,0,0);
		location = new Vector3(_x, _y,0);
		r = 3.0f;
		maxspeed = 5;
		maxforce = 0.1f;
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
		Vector3 steer = desired - velocity;
		steer = CS.ConstrainVector3(steer, maxforce);
		applyForce(steer);
	}

	public void arrive(Vector3 _target)
	{
		Vector3 desired = _target - location;
		float d = desired.magnitude;
		desired.Normalize();
		if (d < 3)
		{
			float m = CS.Remap(d, 0, 3, 0, maxspeed);
			desired *= m;
		}
		else
		{
			desired *= maxspeed;
		}

		Vector3 steer = desired - velocity;
		steer = CS.ConstrainVector3(steer, maxforce);
		applyForce(steer);
	}
 
	public void display()
	{
		
		vehicle61.transform.position = new Vector3(location.x, location.y, 0); // constrained Z
		var newRotation = Quaternion.LookRotation(velocity).eulerAngles;  // 
		newRotation.z = 0; // Constrain Rotation
		vehicle61.transform.rotation = Quaternion.Euler(newRotation);


	}
}
