using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class Example_4_6 : MonoBehaviour
{

	private List<ParticleSystem_4_6> systems;

	// Use this for initialization
	void Start () {
		systems = new List<ParticleSystem_4_6>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 aPlace = CS.MousePositionfromCam();
			systems.Add(new ParticleSystem_4_6(aPlace));
			//Debug.Log("MouseClicked. " + aPlace);
		}

		foreach (var PS in systems)
		{
			PS.run();
			PS.AddParticle();
		}
	}

}


public class ParticleSystem_4_6 : MonoBehaviour
{
	private List<Particle_4_6> particles;
	public Vector3 origin = new Vector3(8,8,0);
	public Vector3 gravity = new Vector3(0, -1, 0);

	
	public ParticleSystem_4_6(Vector3 _location)
	{
		origin = _location;
		particles = new List<Particle_4_6>();
		
//		Debug.Log("I ran.");
		
	}

	public void run()
	{
		for (int i = particles.Count-1; i >= 0; i--)
		{
			particles[i].applyForce(gravity);
			particles[i].run();
			if (particles[i].isDead())
			{
				Destroy(particles[i].particle_type);
				particles.Remove(particles[i]);
			}
		}	
	}

	public void AddParticle()
	{
		float r = Random.value;
		if (r <= 0.33f)
		{
			particles.Add(new Confetti_4_6(origin,1f, CS.RandVec3DXY(-0.1f, 0.1f), GameObject.CreatePrimitive(PrimitiveType.Cube)));
		}
		else if (r <= 0.66f)
		{
			particles.Add(new SphereParticle_4_6(origin,1f, CS.RandVec3DXY(-0.1f, 0.1f), GameObject.CreatePrimitive(PrimitiveType.Sphere)));

		}
		else
		{
			particles.Add(new CapsuleParticle_4_6(origin,1f, CS.RandVec3DXY(-0.1f, 0.1f), GameObject.CreatePrimitive(PrimitiveType.Capsule)));

		}
		
	}
	
}


public class Confetti_4_6 : Particle_4_6
{
	public Confetti_4_6(Vector3 _location, float _lifespan, Vector3 _velocity, GameObject _particleType) : base(_location, _lifespan, _velocity, _particleType)
	{
		
	}
}

public class SphereParticle_4_6 : Particle_4_6
{
	public SphereParticle_4_6(Vector3 _location, float _lifespan, Vector3 _velocity, GameObject _particleType) : base(_location, _lifespan, _velocity, _particleType)
	{
		
	}
}

public class CapsuleParticle_4_6 : Particle_4_6
{
	public CapsuleParticle_4_6(Vector3 _location, float _lifespan, Vector3 _velocity, GameObject _particleType) : base(_location, _lifespan, _velocity, _particleType)
	{
		
	}
}

public class Particle_4_6
{
	public Vector3 location;
	public Vector3 velocity;
	public Vector3 acceleration;
	public GameObject particle_type;
	private float lifespan;
	float mass = 1f; //TODO THIS IS A MAGIC NUMEBR! BAD!

	// le Constructeur
	public Particle_4_6(Vector3 _location, float _lifespan, Vector3 _velocity, GameObject _particleType)
	{
		location = _location;
		acceleration = new Vector3(0, -10, 0);
		velocity = _velocity;
		lifespan = _lifespan;
		particle_type = _particleType;
		this.display();	

	}

	public void run()
	{ 
		update();
		display();
		isDead();
	}
	
	public void applyForce(Vector3 _force)
	{
		Vector3 f = _force;
		f = f / mass;
		acceleration += f;
	}

	public void update()
	{
		velocity = velocity + acceleration * Time.deltaTime;
		
		location += velocity;
		lifespan -= 1 * Time.deltaTime;
		acceleration *= 0;
	}

	public void display()
	{
		particle_type.transform.position = location;
		particle_type.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
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