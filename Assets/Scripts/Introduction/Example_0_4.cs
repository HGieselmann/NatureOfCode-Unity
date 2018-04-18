// THIS IS A PORT OF THE EXAMPLES FROM DANIEL SHIFFMANS BOOK "THE NATURE OF CODE" //
// The Original is found here: http://natureofcode.com/ and Licensed under : -----//
// Creative Commons Attribution-NonCommercial 3.0 Unported License. --------------//
// The Code Examples are licensend under:  GNU Lesser General Public License. ----//
// And so this Code is also licensed under:  GNU Lesser General Public License ---//
// I merely try to convert the Examples for Unity for personal use. If this helps //
// anyone else, I'm glad you found this Repo. Enjoy! -----------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example_0_4 : MonoBehaviour
{
	private GameObject[] cubes = new GameObject[10];
	private GameObject sphere;
	public float spherePos = 0;
	public Material semi;

	private double _laplacian;
	// Use this for initialization
	void Start () {
		
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.GetComponent<Renderer>().material = semi;


		for (int i = 0; i < cubes.Length; i++)
		{
			cubes[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cubes[i].transform.position = new Vector3( (-cubes.Length/2)+ i, 0, 0);
			cubes[i].transform.localScale = new Vector3(0.8f, 0, 0.8f);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		_laplacian = NextLaplacianDouble();
		_laplacian = NormalizeLaplacian(_laplacian, 0, cubes.Length);
		// TODO implement Code to check for Values outside of 99.7%;

		sphere.transform.position = new Vector3((float)_laplacian - cubes.Length /2, spherePos, 0);
		
		
		for (int i = 0; i < cubes.Length; i++)
		{
			if ((int) _laplacian == i)
			{
				cubes[i].transform.localScale += new Vector3(0, (float)1/100, 0);
			}
		}
		
		
		
	}


	public static double NextLaplacianDouble()
	{
		double u, v, s;

		do
		{
			u = 2.0 * UnityEngine.Random.value - 1.0;
			v = 2.0 * UnityEngine.Random.value - 1.0;
			s = u * u + v * v;
		}
		while (s >= 1.0);

		float sf = (float)s;
		double fac = Mathf.Sqrt((float)-2.0 * Mathf.Log(sf) / sf);
		return u * fac;
	}

	public static double NormalizeLaplacian(double _lap, float _min, float _max)
	{
		float mean = (_min + _max) / 2;
		float sigma = (_max - mean) / 3;
		return _lap * sigma + mean;
	}

}
