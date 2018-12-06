using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGen : MonoBehaviour {

	public GameObject bedrock;
	private int[,] matrix;
	private int x;
	private int y;
	void Start () 
	{
		x = gameObject.GetComponent<Camera> ().pixelWidth;
		y = gameObject.GetComponent<Camera> ().pixelHeight;
		matrix = new int[x, y];
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				matrix[i][j] = 0;		
			}
		}
		baseGen ();
		for (int i = 0; i < x; i++) {
			for (int j = 0; j < y; j++) {
				if (matrix [i] [j] == 1) {
					
					GameObject projectile = (GameObject)Instantiate(bedrock,new Vector2 (i,j), Quaternion.identity);
				}	
			}
		}
	}
	void baseGen()
	{
		for (int i = 0; i < x; i++) {
			matrix [Random.Range (x, x + 2)] [0] = 1;
		}
	}
}
