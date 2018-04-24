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

public class Example_0_1 : MonoBehaviour
{
	public static float CSizeX = 16;
	public static float CSizeY = 9;

	public Example_0_1_Walker Walker;

	private GameObject sphere;
	
	// Use this for initialization
	void Start ()
	{
		Walker = new Example_0_1_Walker(CSizeX/2, CSizeY/2, 0f);
		Debug.Log(Walker);
		sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

	}
	
	// Update is called once per frame
	void Update () {
		//Walker = gameObject.AddComponent<Example_0_1_Walker>();
		Debug.Log(Walker);
		Debug.Log(Walker.position);
		Walker.RandomMove();
		//Walker.Display();
		sphere.transform.position = Walker.position/10;
	}
}
