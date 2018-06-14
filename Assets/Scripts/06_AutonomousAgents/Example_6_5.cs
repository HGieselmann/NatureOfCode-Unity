using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_6_5 : MonoBehaviour
{

	public Vehicle_6_5 Vehicle_6_5;
	private Example_6_5_Path example65Path;
	public LineRenderer pathLine;
	
	

	// Use this for initialization
	void Start ()
	{
		
		example65Path = new Example_6_5_Path();
		Vehicle_6_5 = new Vehicle_6_5(0, 4f);
		pathLine = gameObject.AddComponent<LineRenderer>();
		pathLine.SetPosition(0, example65Path.pathStart);
		pathLine.SetPosition(1, example65Path.pathEnd);
		pathLine.widthMultiplier = 0.1f;
		pathLine.startColor = Color.white;
		pathLine.endColor = Color.white;


	}
	
	// Update is called once per frame
	void Update () {
		Vehicle_6_5.update();
		Vehicle_6_5.follow(example65Path);
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
	public GameObject vehicle65;
 
	public Vehicle_6_5(float _x, float _y) {
		acceleration = new Vector3(0,0,0);
		velocity = new Vector3(1,0,0);
		location = new Vector3(_x, _y, 0);
		r = 3.0f;
		maxspeed = 20f;
		maxforce = 1f;
		vehicle65 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		vehicle65.transform.localScale= new Vector3(.2f, .2f, .4f);
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

	public void follow(Example_6_5_Path _path)
	{
		Vector3 predict = velocity;
		predict.Normalize();
		predict *= 1;
		Vector3 predictedPos = predict + location;

		Vector3 a = _path.pathStart;
		Vector3 b = _path.pathEnd;

		Vector3 normalPoint = getNormalPoint(predictedPos, a, b);

		Vector3 dir = b - a;
		dir.Normalize();
		dir *= 2;
		Vector3 target = normalPoint + dir;

		float distance = Vector3.Distance(predictedPos, normalPoint);
		if (distance > _path.pathRadius)
		{
			seek(target);
		}
	}

	public Vector3 getNormalPoint(Vector3 _p, Vector3 _a, Vector3 _b)
	{
		Vector3 ap = _p - _a;
		Vector3 ab = _b - _a;
		ab.Normalize();
		ab *= Vector3.Dot(ap, ab);
		Vector3 normalPoint = _a + ab;
		return normalPoint;
	}
 
	public void display()
	{
		
		vehicle65.transform.position = new Vector3(location.x, location.y, 0); // constrained Z
		var newRotation = Quaternion.LookRotation(velocity).eulerAngles;  // 
		newRotation.z = 0; // Constrain Rotation
		vehicle65.transform.rotation = Quaternion.Euler(newRotation);


	}

	public void CheckEdges()
	{
		if (location.x < 0)
		{
			location.x = 16;
		} else if (location.x > 16)
		{
			location.x = 0;
			location.y = Random.RandomRange(0f, 9f);
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



public class Example_6_5_Path
{
	public Vector3 pathStart;
	public Vector3 pathEnd;
	public float pathRadius;
	
	public Example_6_5_Path()
	{
		pathRadius = 0.1f;
		pathStart = new Vector3(0, 8, 0);
		pathEnd = new Vector3(16, 2, 0);
	}
	
	
}