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
	bool goHome = false; 
	bool warp = false;
    public bool crashing = false;
    bool action = false;
	bool reset = false;

    private float x; //location
	private float y; 

	public float lastx = 0;
	public float lasty = 0; //previous location

	private float posY = 0.0f;
	private float posX = 0.0f;
    public int Item = 0; // 도토리 

	private MapMaking mapData;
	private GameSetup setup;
	private string Playername;
	private bool goTarget = true; //if true go to the Target place otherwise go home so if true 



	// Use this for initialization
	void Start () {
		Playername = "First"; //setting name of mouse
	}

	void Awake(){
		mapData = Map.GetComponent<MapMaking> ();
		setup = gamesetup.GetComponent<GameSetup> ();
	}
	
	// Update is called once per frame
	void Update () {
		moveCheck ();

		if (reset) {
			mapData.TileReset (Playername);//with parameter sending 
			setup.resetPosition(Playername);
			locationCheck = true;
			goTarget = true; 
			goHome = false; 
			reset = false;
		}

        if (up) {
			posY = y + 1.0f;

			//bool action = false;

			if (BoundaryCheck ((int)x, (int)posY)) {
	
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				up = false; // play once 
				locationCheck = true;

			}
			//Obstacle check
			else if (Observer ((int)x, (int)posY) == 3) {

				Debug.Log ("Meet Obstacle!");
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				up = false; // play once 
				locationCheck = true;

			}

            else if (PlayerCheck((int)x,(int)posY) == true)
            {
                //If crash another character

                Debug.Log("Crashing with another Player");

                transform.position = new Vector3((int)lastx, 1, (int)lasty);
                action = false;
                up = false; // play once 
				locationCheck = true;

            }

            else if (Observer ((int)x, (int)posY) == 2) {
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				up = false; // play once 
				locationCheck = true;

				goHome = true;

				if (goTarget) {
					endCheck = true;
					goTarget = false;
				}


			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x >= x && transform.position.z >= posY) {
					run = 0;
					up = false; // play once 
					locationCheck = true;
                    action = false;

                } else {
					run = 1;
				}
				transform.Translate (Vector3.forward * Time.deltaTime * speed * run);

			
			}
				
		} else if (down) {

			posY = y - 1.0f;

			//bool action = false;

			if (BoundaryCheck ((int)x, (int)posY)) {

				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				down = false;
				locationCheck = true;

            }

			else if (Observer ((int)x, (int)posY) == 3) {

				Debug.Log ("Meet Obstacle!");
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				down = false; // play once 
				locationCheck = true;

			}

            else if (PlayerCheck((int)x, (int)posY) == true)
            {
                //If crash another character

                Debug.Log("Crashing with another Player");
                transform.position = new Vector3((int)lastx, 1, (int)lasty);
                action = false;
                down = false; // play once 
				locationCheck = true;

            }

            else if (Observer ((int)x, (int)posY) == 2) {
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				down = false; // play once
				locationCheck = true;

				goHome = true;

				if (goTarget) {
					endCheck = true;
					goTarget = false;
				}


			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x >= x && transform.position.z <= posY) {
					run = 0;
					down = false; // play once 
                    action = false;
					locationCheck = true;

                }
                else {
					run = 1;
				}
				transform.Translate (Vector3.back * Time.deltaTime * speed * run);
			
			}
				

		} else if (left) {

			posX = x - 1.0f;

//			bool action = false;

			if (BoundaryCheck ((int)posX, (int)y)) {
				
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				left = false; // play once 
				locationCheck = true;

			}

			else if (Observer ((int)posX, (int)y) == 3) {

				Debug.Log ("Meet Obstacle!");
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				left = false; // play once 
				locationCheck = true;

			}


            else if (PlayerCheck((int)posX, (int)y) == true)
            {
                //If crash another character

                Debug.Log("Crashing with another Player");

                transform.position = new Vector3((int)lastx, 1, (int)lasty);
                action = false;
                left = false; // play once 
				locationCheck = true;

            }

            else if (Observer ((int)posX, (int)y) == 2) {
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);

				locationCheck = true;
				left = false; // play once 

				goHome = true;

				if (goTarget) {
					endCheck = true;
					goTarget = false;
				}
	
			} else {
				action = true;
			}

			if (action == true) {
			
				if (transform.position.x <= posX && transform.position.z >= y) {
					locationCheck = true;
					Debug.Log ("Arrived");
					run = 0;
					left = false;
                    action = false;


                }
                else {
					run = 1;
				}
				transform.Translate (Vector3.left * Time.deltaTime * speed * run);
			}
				
		
		} else if (right) {

			posX = x + 1.0f;

			//bool action = false;

			if (BoundaryCheck ((int)posX, (int)y) == true) {
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				right = false; // play once 
				locationCheck = true;
			}

			else if (Observer ((int)posX, (int)y) == 3) {

				Debug.Log ("Meet Obstacle!");
				transform.position = new Vector3 ((int)x, 1, (int)y);
				action = false;
				right = false; // play once 
				locationCheck = true;


			}

            else if (PlayerCheck((int)posX, (int)y) == true)
            {
                //If crash another character

                Debug.Log("Crashing with another Player");

                transform.position = new Vector3((int)lastx, 1, (int)lasty);
                action = false;
                right = false; // play once 
				locationCheck = true;

            }

            else if (Observer ((int)posX, (int)y) == 2) {
				action = false;
				transform.position = new Vector3 ((int)lastx, 1, (int)lasty);
				locationCheck = true;
				right = false; // play once 


				goHome = true;

				if (goTarget) {
					endCheck = true;
					goTarget = false;
				}

			} else {
				action = true;
			}


			if (action == true) {
				
				if (transform.position.x >= posX && transform.position.z >= y) {
				
					locationCheck = true;
					//Debug.Log ("Arrived");
					run = 0;
					right = false;
                    action = false;

                }
                else {
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
			//Debug.Log (goHome);
			//Debug.Log (goTarget);
		

			mapData.TileBuilder (Playername);//with parameter sending 
	
			endCheck = false;

			//Debug.Log (endCheck);

		}

		if (warp) {
			Warp ();

			warp = false;
		}
			
			
	}

	void getCurrentLocation(){
		
		x = (int)Mathf.Round(Player.gameObject.transform.position.x);
		y = (int)Mathf.Round(Player.gameObject.transform.position.z); 
		//current location 

		transform.position = new Vector3(x,1,y);

		if (Observer ((int)x, (int)y) == 0) {
			//Start Event
			//which house ?
			if ((int)x == 4 && (int)y == 0) {
				//First's house 
				if (Playername == "First") {
					
					goTarget = true;

					if (goHome) {
						endCheck = true;
						goHome = false;

						Debug.Log (goHome);
					}
				}

			} else if ((int)x == 8 && (int)y == 4) {
				//second's house

				if (Playername == "Second") {

					goTarget = true;

					if (goHome) {
						endCheck = true;
						goHome = false;

						Debug.Log (goHome);
					}
				}
			
			} else if ((int)x == 4 && (int)y == 8) {
				//third's house

				if (Playername == "Third") {

					goTarget = true;

					if (goHome) {
						endCheck = true;
						goHome = false;

						Debug.Log (goHome);
					}
				}

			} else if ((int)x == 0 && (int)y == 4) {
				//fourth's house
			
				if (Playername == "Fourth") {

					goTarget = true;

					if (goHome) {
						endCheck = true;
						goHome = false;

						Debug.Log (goHome);
					}
				}

			}

		} else if (Observer ((int)x, (int)y) == 1) {
			//Road Event

		} else if (Observer ((int)x, (int)y) == 2) {
			//End Event

		} else if (Observer ((int)x, (int)y) == 3) {
			//Obstacle Event
		//	Debug.Log("Obstacle Point");
		//	transform.position = new Vector3 ((int)lastx, 1, (int)lasty);

		}
		else if (Observer ((int)x, (int)y) == 4) {
			//Warp Event
			Debug.Log("Warp Point");
			warp = true; // if warp true 

		}

		if (BoundaryCheck ((int)x, (int)y)) {
			setLastlocation ();
		}

	
	}

	void moveCheck(){

		if (locationCheck) {
			getCurrentLocation ();
			setLastlocation ();
		}

		if(Input.GetKeyDown(KeyCode.Z)){
			Debug.Log ("Key pressed reset");
			reset = true;
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
		} else if (tileType == 4) {
			return 4; 
		} else {
			return 5;	//nothing mean 
		}
		
	}

	void Warp(){

		//Debug.Log ("Player :  " + (int)setup.playerLocation [0].x + " " + (int)setup.playerLocation [0].y); player
		//Debug.Log("Player : " + mapData.tilexy[0].obstacle[0].x + " " + mapData.tilexy[0].obstacle[0].y); obstacle
		//Debug.Log("Player : " + mapData.tilexy[0].Warp[0].x + " " + mapData.tilexy[0].Warp[0].y); warp 

		int WarpX = Random.Range (0, 8);
		int WarpY = Random.Range (0, 8);
		int count_Warp = 0;
			
			for (int i = 0; i < (int)setup.playerLocation.Length; i++) {
				if (WarpX != (int)setup.playerLocation [i].x && WarpY != (int)setup.playerLocation [i].y) {
					count_Warp++;
				}
			}

			if (count_Warp == 4) {
				//no match Player location 

				for (int i = 0; i < mapData.ObstacleCount; i++) {
					if (WarpX != mapData.tilexy [0].obstacle [i].x && WarpY != mapData.tilexy [0].obstacle [i].y) {
						count_Warp++;
					}
				}
	
			}
				

			if (count_Warp == 4 + (mapData.ObstacleCount - 1)) {
			//no match obstacle
				for (int i = 0; i < mapData.tilexy [0].Warp.Length; i++) {

				if (WarpX != mapData.tilexy [0].Warp [i].x && WarpY != mapData.tilexy [0].Warp [i].y) {
					count_Warp++;
				}
			}

		}

		if (count_Warp == 8 + (mapData.ObstacleCount - 1)) {
			Debug.Log ("Determined : " + WarpX + " " + WarpY);
			transform.position = new Vector3 (WarpX, 1, WarpY);
		}

			
	}


	void setLastlocation(){
		lastx = (int)transform.position.x;
		lasty = (int)transform.position.z;

		if (Observer ((int)lastx, (int)lasty) == 4) {
			warp = true;
		}
	}

    bool PlayerCheck(int a, int b)
    {
        int count = 0;

        for (int i = 0; i < setup.playerLocation.Length; i++)
        {
            if (a == setup.playerLocation[i].x && b == setup.playerLocation[i].y)
            {
                count++;
            }

        }

        if (count >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }

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
//MAKE WARP AND PLAYER 2 , 3 , 4 돌아 올 때도 랜덤