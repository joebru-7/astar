using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiler : MonoBehaviour
{

	int Width = 10;
	int Height = 10;
	// Start is called before the first frame update
	void Start()
	{
		Destroy(this);
		for (int i = -Width; i < Width; i++)
		{
			for (int j = -Height; j < Height; j++)
			{
				Instantiate(gameObject, new Vector3(i,j), Quaternion.identity);
			}
		}
	}
}
