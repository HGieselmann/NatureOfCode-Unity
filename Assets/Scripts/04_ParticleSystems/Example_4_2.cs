using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_4_2 : MonoBehaviour
{

	public int PCount = 200;

	private List<Particle_4_2> PList;

	// Use this for initialization
	void Start () {
		PList = new List<Particle_4_2>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		PList.Add(new Particle_4_2(new Vector3(8, 8,0),1f, RandV()));
		for (int i = PList.Count-1; i >= 0; i--)
		{
			PList[i].run();
			if (PList[i].isDead())
			{
				Destroy(PList[i].sphere);
				PList.Remove(PList[i]);
			}
		}	
	}

	public Vector3 RandV()
	{
		Vector3 v = new Vector3(UnityEngine.Random.Range(-0.1f, .1f), UnityEngine.Random.RandomRange(-0.1f, .1f), 0f);
		return v;
	}
}


public class Particle_4_2
{
	public Vector3 location;
	public Vector3 velocity;
	public Vector3 acceleration;
	public GameObject sphere;
	private float lifespan;

	// le Constructeur
	public Particle_4_2(Vector3 _location, float _lifespan, Vector3 _velocity)
	{
		location = _location;
		acceleration = new Vector3(0, -1, 0);
		velocity = _velocity;
		lifespan = _lifespan;
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		this.display();

	}

	public void run()
	{ 
		update();
		display();
		isDead();
	}

	public void update()
	{
		velocity = velocity + acceleration * Time.deltaTime;
		location += velocity;
		lifespan -= 1 * Time.deltaTime;
	}

	public void display()
	{
		sphere.transform.position = location;
		sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
	}

	public bool isDead()
	{
		if (lifespan <= 0.0f)
		{
			return true;
		}
		else
		{
			return false;
		}
	}



}