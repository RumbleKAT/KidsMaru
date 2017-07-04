using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public GameObject Player;	
	public GameObject Map;
	public GameObject gamesetup;

	public float speed = 0.4f;
	public int run = 0;
	public int tileType;

	bool up = false;
	bool down = false;
	bool left = false;
	bool right = false;
	bool locationCheck = true;
	bool endCheck = false;
	//bool savelocation = true;

	private float x; //location
	private float y; 

	private float lastx = 0;
	private float lasty = 0; //previous location

	private float posY = 0.0f;
	private float posX = 0.0f;

	private MapMaking mapData;
	private int count;
	public string name = "";


	// Use this for initialization
	void Start () {
		count = 1;
		//name = "First"; //setting name of mouse
	}

	void Awake(){
		mapData = Map.GetComponent<MapMaking> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveCheck ();

		if (up) {
			posY = y + 1.0f;

			bool action = false;

			if (BoundaryCheck ((int)x, (int)posY)) {
	
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				up = false; // play once 

			} else if (Observer ((int)x, (int)posY) == 2) {
				Debug.Log ("End!"); //end  
				endCheck = true;
			
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				locationCheck = true;
				up = false; // play once 

			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x >= x && transform.position.z >= posY) {
					run = 0;
					up = false; // play once 
					locationCheck = true;

				} else {
					run = 1;
				}
				transform.Translate (Vector3.forward * Time.deltaTime * speed * run);

			
			}
				
		} else if (down) {

			posY = y - 1.0f;

			bool action = false;

			if (BoundaryCheck ((int)x, (int)posY)) {

				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				down = false;

			} else if (Observer ((int)x, (int)posY) == 2) {

				Debug.Log ("End!"); //end  
				//endCheck = true;
				            
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				locationCheck = true;
				down = false; // play once 
			
			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x >= x && transform.position.z <= posY) {
					run = 0;
					down = false; // play once 
					locationCheck = true;

				} else {
					run = 1;
				}
				transform.Translate (Vector3.back * Time.deltaTime * speed * run);
			
			}
				

		} else if (left) {

			posX = x - 1.0f;

			bool action = false;

			if (BoundaryCheck ((int)posX, (int)y)) {
	
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				up = false; // play once 

			} else if (Observer ((int)posX, (int)y) == 2) {

				Debug.Log ("End!");
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);

				locationCheck = true;
				left = false; // play once 
	
			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x <= posX && transform.position.z >= y) {
					locationCheck = true;
					Debug.Log ("Arrived");
					run = 0;
					left = false;

				} else {
					run = 1;
				}
				transform.Translate (Vector3.left * Time.deltaTime * speed * run);
			}
				
		
		} else if (right) {

			posX = x + 1.0f;

			bool action = false;

			if (BoundaryCheck ((int)posX, (int)y) == true) {
				//Debug.Log ("Crash");
				//Debug.Log (x + " " + y); 
				transform.position = new Vector3 ((int)x, 1, (int)y);
			} else if (Observer ((int)posX, (int)y) == 2) {
				Debug.Log ("End!"); //end  
				//endCheck = true;
				            
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				locationCheck = true;
				right = false; // play once 

			} else {
				action = true;
			}


			if (action == true) {
				
				if (transform.position.x >= posX && transform.position.z >= y) {
				
					locationCheck = true;
					Debug.Log ("Arrived");
					run = 0;
					right = false;

				} else {
					run = 1;
				}
				transform.Translate (Vector3.right * Time.deltaTime * speed * run);
			} 
		}

		else {
			posX = 10.0f;
			posY = 10.0f;
		}


		if (endCheck) {

			if (count <= 3) {
				mapData.TileBuilder (count,name);//with parameter sending 
				count++;
			}

			//Debug.Log (count);
			endCheck = false;

			Debug.Log (endCheck);

		}
			
	}

	void getCurrentLocation(){
		
		x = (int)Mathf.Round(Player.gameObject.transform.position.x);
		y = (int)Mathf.Round(Player.gameObject.transform.position.z); 
		//current location 

		transform.position = new Vector3(x,1,y);

		if (Observer ((int)x, (int)y) == 0) {
			//Start Event

		} else if (Observer ((int)x, (int)y) == 1) {
			//Road Event

		} else if (Observer ((int)x, (int)y) == 2) {
			//End Event
		//	transform.position = new Vector3 ((int)lastx, 1, (int)lasty); //action 
		//	Debug.Log("lastX : " + lastx + " " + "lastY : " + lasty);
		//	Debug.Log("End Point");
		//	endCheck = true; checking the 

		} else if (Observer ((int)x, (int)y) == 3) {
			//Obstacle Event
			Debug.Log("Obstacle Point");
			transform.position = new Vector3 ((int)lastx, 1, (int)lasty);

		}

	
	}

	void moveCheck(){

		if (locationCheck) {
			getCurrentLocation ();
			setLastlocation ();
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			getCurrentLocation ();
			locationCheck = false;
			up = true; //moving action!
			down = false;
			left = false;
			right = false;
		}

		if (Input.GetKeyDown (KeyCode.S)) {
			getCurrentLocation ();
			locationCheck = false;
			down = true;
			up = false; //moving action!
			left = false;
			right = false;
		}

		if (Input.GetKeyDown (KeyCode.A)) {
			getCurrentLocation ();
			locationCheck = false;
			down = false;
			up = false; //moving action!
			left = true;
			right = false;
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			getCurrentLocation ();
			locationCheck = false;
			down = false;
			up = false; //moving action!
			left = false;
			right = true;
		}

	}

	//which method watching the tile information
	public int Observer(int x, int y){

		tileType = mapData.getTileData (x, y);

		if (tileType == 0) {
			return 0;

		} else if (tileType == 1) {
			return 1;

		} else if (tileType == 2) {
			return 2;

		} else if (tileType == 3) {
			return 3;
		} else {
			return 4; //nothing mean
		}
		
	}
		


	void setLastlocation(){
		lastx = (int)transform.position.x;
		lasty = (int)transform.position.z;

		//Debug.Log ("lastX : " + lastx + " " + "lastY : " + lasty);
	}

	bool BoundaryCheck(int a, int b){
		if (a < 0 || b < 0) {
			Debug.Log ("away from land");
			x = (int)(lastx); 
			y = (int)(lasty);
			return true;
		} else if (a > 8 || b > 8) {
			Debug.Log ("away from land");
			x = (int)(lastx); 
			y = (int)(lasty);
			return true;
		} else {
			return false;
		}
	}
}
