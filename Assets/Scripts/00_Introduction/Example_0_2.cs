using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_0_2 : MonoBehaviour
{

	public GameObject[] cubes = new GameObject[10];
	private int cycles = 0;
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < cubes.Length; i++)
		{
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i].transform.localScale = new Vector3(0.8f,0,0.8f);
			cubes[i].transform.position = new Vector3(i-cubes.Length/2, 0.5f, 0.5f);
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		cycles++;
		int rand =UnityEngine.Random.RandomRange(0, cubes.Length + 1);
		for (int i = 0; i < cubes.Length; i++)
		{
			if (i == rand)
			{
				cubes[i].transform.localScale += new Vector3(0, 0.005f, 0);

			}
		}


	}
}
