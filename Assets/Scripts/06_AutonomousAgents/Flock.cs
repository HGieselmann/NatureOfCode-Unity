using System.Collections.Generic;
using UnityEngine;

public class Flock
{
    public List<Example_6_9_Boid> boids;
    public List<GameObject> Fishes;

    public Flock()
    {
        boids = new List<Example_6_9_Boid>();
        Fishes = new List<GameObject>();
    }

    public void run()
    {
        for (int i = 0; i < boids.Count; i++)
        {
            boids[i].run(boids);
        }
        
        for (int i = 0; i < Fishes.Count; i++)
        {
            Fishes[i].transform.position = boids[i].position;
            Fishes[i].transform.rotation = Quaternion.LookRotation(boids[i].velocity);
        }
    }

    public void addBoid(Example_6_9_Boid b)
    {
        boids.Add(b);
    }
    
    public void addFish(GameObject _fish) 
    {
        Fishes.Add(_fish);
    }
}