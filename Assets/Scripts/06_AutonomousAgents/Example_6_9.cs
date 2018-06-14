using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_6_9 : MonoBehaviour
{
	public Example_6_9_Flock flock;
	public GameObject FishGameObject;

	// Use this for initialization
	void Start () {
		flock = new Example_6_9_Flock();
		for (int i = 0; i < 20; i++)
		{
			Example_6_9_Boid b = new Example_6_9_Boid( Random.RandomRange(-1,1), Random.RandomRange(-1,1), Random.RandomRange(-1,1));
			flock.addBoid(b);

			GameObject _b = Instantiate(FishGameObject) as GameObject;
			flock.addFish(_b);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		flock.run();
		
	}
}
