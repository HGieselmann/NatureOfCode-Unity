using UnityEngine;

public class Bob
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
    public float mass = 1;
    public Vector3 force;

    public float damping = 0.99f;
	
	
    public Bob(float _x, float _y)
    {
        position = new Vector3(_x, _y, 0);
        velocity = new Vector3();
        acceleration = new Vector3();
		
    }

    public void update()
    {
        velocity += acceleration;
        velocity *= damping;
        position += velocity;
        acceleration *= 0;
    }

    public void applyForce(Vector3 _force)
    {
        force = _force;
        force = force / mass;
        acceleration = force;
    }
}