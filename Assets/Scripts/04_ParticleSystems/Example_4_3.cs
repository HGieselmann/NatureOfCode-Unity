using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_4_3 : MonoBehaviour
{

	private ParticleSystem_4_3 ps;

	// Use this for initialization
	void Start () {
		ps = new ParticleSystem_4_3(new Vector3(8,8,0));
		
	}
	
	// Update is called once per frame
	void Update ()
	{

		ps.AddParticle();
		ps.run();
		
	}

	public Vector3 RandV()
	{
		Vector3 v = new Vector3(UnityEngine.Random.Range(-0.1f, .1f), UnityEngine.Random.RandomRange(-0.1f, .1f), 0f);
		return v;
	}
}


public class ParticleSystem_4_3 : MonoBehaviour
{
	private List<Particle_4_3> particles;

	public ParticleSystem_4_3(Vector3 _location)
	{
		Vector3 origin = _location;
		particles = new List<Particle_4_3>();
		
	}

	public void run()
	{
		for (int i = particles.Count-1; i >= 0; i--)
		{
			particles[i].run();
			if (particles[i].isDead())
			{
				Destroy(particles[i].sphere);
				particles.Remove(particles[i]);
			}
		}	
	}

	public void AddParticle()
	{
		particles.Add(new Particle_4_3(new Vector3(8, 8,0),1f, RandV()));
	}
	
	public Vector3 RandV()
	{
		Vector3 v = new Vector3(UnityEngine.Random.Range(-0.1f, .1f), UnityEngine.Random.RandomRange(-0.1f, .1f), 0f);
		return v;
	}
}

public class Particle_4_3
{
	public Vector3 location;
	public Vector3 velocity;
	public Vector3 acceleration;
	public GameObject sphere;
	private float lifespan;

	// le Constructeur
	public Particle_4_3(Vector3 _location, float _lifespan, Vector3 _velocity)
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