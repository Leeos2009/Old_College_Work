using UnityEngine;
using System.Collections;

public class Checkers : MonoBehaviour
{
	int side = 0, front = 0;

	void Start()
	{
		for (front = 0; front <= 7; front++)
		{
			for (side = 0; side <= 7; side++)
			{
				GameObject Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				Cube.transform.position = new Vector3(side, 1.5f, front);
				Cube.name = "Cube R " + side + " C " + front;
				if (side % 2 == 0 && front % 2 == 0)
				{
					Cube.GetComponent<Renderer>().material.color = Color.blue;

					if (side <= 3 )
					{//Black Checkers Rows 1 & 3
						GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
						Cylinder.transform.position = new Vector3(side, 2.2f, front);
						Cylinder.name = "Checker R " + side + " C " + front;
						Cylinder.transform.localScale += new Vector3(-.25f, -.8f, -.25f);
						Cylinder.GetComponent<Renderer>().material.color = Color.black;
						Cylinder.tag = "Black";
					}
				}
				else if (front % 2 != 0 && side % 2 != 0)
				{
					Cube.GetComponent<Renderer>().material.color = Color.blue;
					if (side >= 5 )
					{//White Checkers Row 6 & 8
						GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
						Cylinder.transform.position = new Vector3(side, 2.2f, front);
						Cylinder.name = "Checker R " + side + " C " + front;
						Cylinder.transform.localScale += new Vector3(-.25f, -.8f, -.25f);
						Cylinder.GetComponent<Renderer>().material.color = Color.white;
						Cylinder.tag = "White"; 
					}
				}
				if (side == 1 && front % 2 != 0)
				{//Spawning checkers for Row 2
					GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
					Cylinder.transform.position = new Vector3(side, 2.2f, front);
					Cylinder.name = "Checker R " + side + " C " + front;
					Cylinder.transform.localScale += new Vector3(-.25f, -.8f, -.25f);
					Cylinder.GetComponent<Renderer>().material.color = Color.black;
					Cylinder.tag = "Black";
				}
				if (side == 6 && front % 2 == 0)
				{
					GameObject Cylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
					Cylinder.transform.position = new Vector3(side, 2.2f, front);
					Cylinder.name = "Checker R " + side + " C " + front;
					Cylinder.transform.localScale += new Vector3(-.25f, -.8f, -.25f);
					Cylinder.GetComponent<Renderer>().material.color = Color.white;
					Cylinder.tag = "White";
				}
			}
		}
	}


	void Update()
	{

	}

}
