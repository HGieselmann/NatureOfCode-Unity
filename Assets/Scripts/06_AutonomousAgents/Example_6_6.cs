using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_6_6 : MonoBehaviour
{

	public Vehicle_6_6 Vehicle_6_6;
	private Example_6_6_Path example66Path;
	public LineRenderer pathLine;
	
	

	// Use this for initialization
	void Start ()
	{
		
		example66Path = new Example_6_6_Path();
		example66Path.addPoint(0,7,0);
		example66Path.addPoint(2,3,0);
		example66Path.addPoint(7,1,0);
		example66Path.addPoint(12,7,0);
		example66Path.addPoint(16,2,0);

		Vehicle_6_6 = new Vehicle_6_6(0, 4f);
		pathLine = gameObject.AddComponent<LineRenderer>();
		pathLine.positionCount = example66Path.points.Count;
		for (int i = 0; i < example66Path.points.Count; i++)
		{
			pathLine.SetPosition(i, example66Path.points[i]);
		}
		pathLine.widthMultiplier = 0.1f;
		pathLine.startColor = Color.white;
		pathLine.endColor = Color.white;


	}
	
	// Update is called once per frame
	void Update () {
		Vehicle_6_6.update();
		Vehicle_6_6.follow(example66Path);
		Vehicle_6_6.display();
		Vehicle_6_6.CheckEdges();

	}
}

public class Vehicle_6_6
{
	public Vector3 location;
	Vector3 velocity;
	Vector3 acceleration;
	float r;
	float maxforce;
	float maxspeed;
	public GameObject vehicle66;
 
	public Vehicle_6_6(float _x, float _y) {
		acceleration = new Vector3(0,0,0);
		velocity = new Vector3(1,0,0);
		location = new Vector3(_x, _y, 0);
		r = 3.0f;
		maxspeed = 10f;
		maxforce = 1f;
		vehicle66 = GameObject.CreatePrimitive(PrimitiveType.Cube);
		vehicle66.transform.localScale= new Vector3(.2f, .2f, .4f);
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

	public void follow(Example_6_6_Path _path)
	{
		Vector3 predict = velocity;
		predict.Normalize();
		predict *= 1;
		Vector3 predictedPos = predict + location;

		Vector3 normal;
		Vector3 target = new Vector3(0,0,0);
		float worldRecord = 1000000;

		for (int i = 0; i < _path.points.Count -1; i++)
		{
			Vector3 a = _path.points[i];
			Vector3 b = _path.points[i + 1];

			Vector3 normalPoint = getNormalPoint(predictedPos, a, b);
			if (normalPoint.x < a.x || normalPoint.x > b.x)
			{
				normalPoint = b;
			}

			float distance = Vector3.Distance(predictedPos, normalPoint);

			if (distance< worldRecord)
			{
				worldRecord = distance;
				normal = normalPoint;

				Vector3 dir = b - a;
				dir.Normalize();
				dir *= 10;
				target = normalPoint;
				target += dir;
			}
		}

		if (worldRecord > _path.pathRadius)
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
		
		vehicle66.transform.position = new Vector3(location.x, location.y, 0); // constrained Z
		var newRotation = Quaternion.LookRotation(velocity).eulerAngles;  // 
		newRotation.z = 0; // Constrain Rotation
		vehicle66.transform.rotation = Quaternion.Euler(newRotation);


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

//		if (location.y < 0)
//		{
//			location.y = 9;
//		}else if (location.y > 9)
//		{
//			location.y = 0;
//		}
	}
}



public class Example_6_6_Path
{
	public List<Vector3> points;
	public float pathRadius;
	
	public Example_6_6_Path()
	{
		pathRadius = 0.1f;
		points = new List<Vector3>();
	}
	
	public void addPoint(float _x, float _y, float _z)
	{
		points.Add(new Vector3(_x, _y, _z));
	}

	public Vector3 getStart()
	{
		return points[0];
	}
	
	public Vector3 getEnd()
	{
		return points[points.Count-1];
	}
	
}