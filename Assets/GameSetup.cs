using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;
	public GameObject Map;

	private MapMaking mapdata;
	public int[,] tiles;
	private TileType [] tiletypes;
	private tileXY [] tilexy;

	public Vector2 [] playerLocation;

	// Use this for initialization
	void Start () {
		settingPosition ();
	}


	// Update is called once per frame
	void LateUpdate () {
		//catchAllLocation();
	}


	void settingPosition(){
		player1.gameObject.transform.position = new Vector3 (4, 1, 0);
	//	player2.gameObject.transform.position = new Vector3 (4, 1, 8);
	//	player3.gameObject.transform.position = new Vector3 (8, 1, 4);
//		player4.gameObject.transform.position = new Vector3 (0, 1, 4);
	}

	void Awake(){
		mapdata = Map.GetComponent<MapMaking> ();
		tilexy = GameObject.Find("GameObject").GetComponents<tileXY>();
		playerLocation = new Vector2[4];

	}

	void showMapdata(){
		
		//Debug.Log (mapdata.getTileData(4,4));

	}


	void catchAllLocation(){
		//save players's location and roadData	

		playerLocation [0].x = player1.gameObject.transform.position.x;
		playerLocation [0].y = player1.gameObject.transform.position.z;

		//Debug.Log ("PlayerLocation X : " + playerLocation [0].x + " " + "PlayerLocation Y : " + playerLocation [0].y);

	}


	void catchObstacleLocation(){


	}


	public bool checkObstacle(int x , int y){

		int check = 0; 

		for (int i = 0; i < tilexy [0].obstacle.Length; i++) {
			//Debug.Log ("Obstacle Data : " + tilexy [0].obstacle [i].x + " ::  " + tilexy[0].obstacle[i].y); //load data;
			//save another array to check obstacle data

			if (x == tilexy [0].obstacle [i].x && y == tilexy [0].obstacle [i].y) {
				//if same value with obstacle data send true
				check = 1;
			}
		}

		if (check != 0) {
			return true;
		} else {
			return false;
		}
	}

}
