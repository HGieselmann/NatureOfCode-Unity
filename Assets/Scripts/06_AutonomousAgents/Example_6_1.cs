using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_6_1 : MonoBehaviour
{

	public Vehicle_6_1 Vehicle_6_1;

	// Use this for initialization
	void Start () {
		Vehicle_6_1 = new Vehicle_6_1(8, 4.5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vehicle_6_1.update();
		Vehicle_6_1.seek(CS.MousePositionfromCam());
		Vehicle_6_1.display();
	}
}

public class Vehicle_6_1
{
	Vector3 location;
	Vector3 velocity;
	Vector3 acceleration;
	float r;
	float maxforce;
	float maxspeed;
	public GameObject vehicle61;
 
	public Vehicle_6_1(float _x, float _y) {
		acceleration = new Vector3(0,0,0);
		velocity = new Vector3(0,0,0);
		location = new Vector3(_x, _y,0);
		r = 3.0f;
		maxspeed = 4;
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
		acceleration += force;
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
 
	public void display()
	{
		
		vehicle61.transform.position = new Vector3(location.x, location.y, 0); // constrained Z
		var newRotation = Quaternion.LookRotation(velocity).eulerAngles;  // 
		newRotation.z = 0; // Constrain Rotation
		vehicle61.transform.rotation = Quaternion.Euler(newRotation);


	}
}
