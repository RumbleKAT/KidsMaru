using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;

	public int previousX;
	public int previousY;
	public MapMaking map;

	public GameObject obdata;
	private tileXY [] tilexy;

	void Start(){
		tileX = 0;
		tileY = 0;

		previousX = tileX;
		previousY = tileY;
		tilexy = GameObject.Find("GameObject").GetComponents<tileXY>();
	}



	void Update(){

		CheckTile (); //checking tile's information 

	}

	bool checkEnd(int x, int y){

		int check = 0;

		if (x == 4 && y == 4) {
			check = 1;
		}

		if (check != 0) {
			return true;
		} else {
			return false;
		}

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

	void CheckTile(){

		if (tileX < 0) {
			//Debug.Log ("away from land2");
			tileX = 0; 
		} else if (tileY < 0) {
			tileY = 0;
		} else if (tileX > 9) {
			tileX = 9;
		} else if (tileY > 9) {
			tileY = 9;
		}

		bool check = checkObstacle (tileX, tileY);

		if (check == true) {
			Debug.Log ("Crash!");
			tileX = previousX;
			tileY = previousY;
			//map.MoveSelectedUnitTo (tileX, tileY); //if meet obstacle 
		} 

		//check End Point 

		bool Endcheck = checkEnd (tileX, tileY);

		if (Endcheck == true) {
			Debug.Log ("Goal");
			tileX = previousX;
			tileY = previousY;
			//map.MoveSelectedUnitTo (tileX, tileY);
		}


		//load obstacle data

		previousX = tileX;
		previousY = tileY; 

		}
	}
