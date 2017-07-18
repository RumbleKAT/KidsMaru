using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileXY : MonoBehaviour {

	public Vector3[] obstacle = new Vector3[10]; //total count of x,y location

	public Vector3 [] RoadType = new Vector3[76]; //obstacle type store

	public Vector2[] Player1Obstacle = new Vector2[7];
	public Vector2[] Player2Obstacle = new Vector2[7];
	public Vector2[] Player3Obstacle = new Vector2[7];
	public Vector2[] Player4Obstacle = new Vector2[7];

	public Vector2[] Warp = new Vector2[4];


	void Start () {
		//Debug.Log(obstacle[0].x);
		//Select();
	}

	void Select(){
		int selection = Random.Range (0, 3); //range index 
		Debug.Log ("Random Selection : " + obstacle [selection].x + " " + obstacle [selection].y); 
	}

}
