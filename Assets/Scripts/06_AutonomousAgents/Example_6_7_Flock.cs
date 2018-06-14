using System.Collections.Generic;
using UnityEngine;

public class Example_6_7_Flock
{
    public List<Example_6_7_Boid> boids;
    

    public Example_6_7_Flock()
    {
        boids = new List<Example_6_7_Boid>();
        
    }

    public void run()
    {
        for (int i = 0; i < boids.Count; i++)
        {
            boids[i].run(boids);
        }
       
    }

    public void addBoid(Example_6_7_Boid b)
    {
        boids.Add(b);
    }
}