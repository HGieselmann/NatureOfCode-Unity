using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_0_4 : MonoBehaviour
{
	public GameObject[] cubes = new GameObject[10];

	private double r;
	// Use this for initialization
	void Start () {

		for (int i = 0; i < cubes.Length; i++)
		{
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i].transform.position = new Vector3( -5+ i, 0, 0);
			cubes[i].transform.localScale = new Vector3(0.8f, 0, 0.8f);
		}
	}
	
	// Update is called once per frame
	void Update () {

		r = NextGaussianDouble() * cubes.Length;
		for (int i = 0; i < cubes.Length; i++)
		{
			if ((int) r == i)
			{
				cubes[i].transform.localScale += new Vector3(0, (float)1/100, 0);
			}
		}
		
		
		
	}


	public static double NextGaussianDouble()
	{
		double u, v, S;

		do
		{
			u = 2.0 * UnityEngine.Random.value - 1.0;
			v = 2.0 * UnityEngine.Random.value - 1.0;
			S = u * u + v * v;
		}
		while (S >= 1.0);

		float Sf = (float)S;
		double fac = Mathf.Sqrt((float)-2.0 * Mathf.Log(Sf) / Sf);
		return u * fac;
	}

}
