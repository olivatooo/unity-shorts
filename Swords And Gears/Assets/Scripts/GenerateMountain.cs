using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMountain : MonoBehaviour {

	[Range (0.1f,20.0f)]
	public float heightScale = 5.0f;
	[Range (0.1f,40.0f)]
	public float detailScale = 5.0f;
	private Mesh myMesh;
	private Vector3[] vertices;

	void Start()
	{
		Generate();
	}
	void Generate(){
		heightScale = Random.Range (0.1f, 10.0f);
		detailScale = Random.Range(0.1f, 10.0f);
		myMesh = this.GetComponent<MeshFilter>().mesh;
		vertices = myMesh.vertices;
		int counter = 0;
		int yLevel = 0;
		for (int i = 0; i < 11; i++) {
			for (int j = 0; j < 11; j++) {
				Calc (counter, yLevel);
				counter++;
			}	
			yLevel++;
		}
		myMesh.vertices = vertices;
		myMesh.RecalculateBounds();
		myMesh.RecalculateNormals();
		Destroy (gameObject.GetComponent<MeshCollider> ());
		MeshCollider collider = gameObject.AddComponent<MeshCollider> ();
		collider.sharedMesh = null;
		collider.sharedMesh = myMesh;
	}
	public bool isWaving = false;
	public float wavingSpeed = 5.0f;
	void Calc(int i, int j)
	{
		if (isWaving) {
			vertices [i].z = Mathf.PerlinNoise (
				Time.time/wavingSpeed+
				(vertices [i].x + transform.position.x) / detailScale,
				Time.time/wavingSpeed+
				(vertices [i].y + transform.position.y) / detailScale) * heightScale;
			vertices [i].z -= j;
		} else if(!isWaving) {
			vertices [i].z = Mathf.PerlinNoise (
				(vertices [i].x + transform.position.x) / detailScale,
				(vertices [i].y + transform.position.y) / detailScale) * heightScale;
			vertices [i].z -= j;
		}
	}
}
