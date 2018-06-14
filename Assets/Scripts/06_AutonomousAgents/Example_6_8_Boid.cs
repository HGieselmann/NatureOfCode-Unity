using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;


public class Example_6_8_Boid
{
    public Vector3 position;
    public Vector3 velocity;
    private Vector3 acceleration;
    private float r;
    private float maxforce;
    private float maxspeed;
    private GameObject sphere;
    


    public Example_6_8_Boid(float _x, float _y, float _z)
    {
        
        sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        
        acceleration = new Vector3(0,0,0);
        velocity = new Vector3(Random.Range(-1, 1),Random.Range(-1, 1), Random.Range(-1, 1) );
        position = new Vector3(_x, _y, _z);
        r = 3.0f;
        maxspeed = 3f;
        maxforce = 0.2f;
    }

    public void run(List<Example_6_8_Boid> _boids)
    {
        flock(_boids);
        update();
        borders();
        
    }

    void applyForce(Vector3 force)
    {
        acceleration += force;
    }

    void flock(List<Example_6_8_Boid> _boids)
    {
        Vector3 sep = separate(_boids);
        Vector3 steer = seek(CS.MousePositionfromCam());
        
        // Weighting
        sep *= 3.5f;
        if (Input.GetMouseButton(0))
        {
            steer *= 1;
        }else if (Input.GetMouseButton(1))
        {
            steer *= -1;
        }
        else
        {
            steer *= 0;
        }

        
        applyForce(sep);
        applyForce(steer);

    }

    void update()
    {
        velocity += acceleration;
        velocity = CS.ConstrainVector3(velocity, maxspeed);
        position += velocity * Time.deltaTime;
        // Constrain to two Axis
        position = new Vector3(position.x, position.y, 0);
        acceleration *= 0;
        sphere.transform.position = position;
    }

    public Vector3 seek(Vector3 _target)
    {
        Vector3 desired = _target - position;
        desired.Normalize();
        desired *= maxspeed;
        Vector3 steer = desired - velocity;
        steer = CS.ConstrainVector3(steer, maxforce);
        return steer;
    }

    public Vector3 separate(List<Example_6_8_Boid> _boids)
    {
        float desiredSep = .25f;
        Vector3 steer = new Vector3();
        int count = 0;
        for (int i = 0; i < _boids.Count; i++)
        {
            float d = Vector3.Distance(position, _boids[i].position);
            if (d > 0 && d < desiredSep)
            {
                Vector3 diff = position - _boids[i].position;
                diff = diff.normalized;
                diff = diff / d;
                steer += diff;
                count++;
            }
        }

        if (count > 0)
        {
            steer /= count;
           
        }

        if (steer.magnitude > 0)
        {
            steer.Normalize();
            steer *= maxspeed;
            steer -= velocity;
            steer = CS.ConstrainVector3(steer, maxforce);
            
        }

        return steer;
    }


    public void borders()
    {
        if (position.x < -0)
        {
            position.x = 16;
        }

        if (position.x > 16)
        {
            position.x = -0;
        }
        if (position.y < -0f)
        {
            position.y = 9;
        }

        if (position.y > 9f)
        {
            position.y = -0f;
        }
//        if (position.z < -4.5f)
//        {
//            position.z = 4.5f;
//        }
//
//        if (position.z > 4.5f)
//        {
//            position.z = -4.5f;
//        }
        
    }

}
