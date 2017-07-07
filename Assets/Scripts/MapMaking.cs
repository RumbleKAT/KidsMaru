using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaking : MonoBehaviour {

	public TileType [] tiletypes;
	public int[,] tiles;
	public tileXY [] tilexy;
	public int ObstacleCount;
	private GameObject[] Tiles;

	public int mapSize = 9;
	private Vector2 LastLocation;
	ClickableTile ct;
	private bool CountUp = false;

//	private bool Player1_Shuffle = true; //after Game End Player's obstacle is removed and reshuffled 
//	private bool Player2_Shuffle = true;
//	private bool Player3_Shuffle = true;
//	private bool Player4_Shuffle = true;



	private int selection; //min value: 0 | max value: 6

	private int [] Player1_ObstacleCount;
	private int [] Player2_ObstacleCount;
	private int [] Player3_ObstacleCount;
	private int [] Player4_ObstacleCount;

	private int P1_ObstacleCount = 0; //Player's Obstacle Count 
	private int P2_ObstacleCount = 0;
	private int P3_ObstacleCount = 0;
	private int P4_ObstacleCount = 0;


	void Start () {

		ObstacleCount = 4; //total counting 
		GenerateMapData (ObstacleCount);
		GenerateMapVisual();

		Player1_ObstacleCount = new int[7];

		MakeShuffle (Player1_ObstacleCount);


		//need reshuffling 

		//Player2_ObstacleCount = new int[7];
		//Player3_ObstacleCount = new int[7];
		//Player4_ObstacleCount = new int[7];


	}

	void GenerateMapData(int size){
		loadObstacle (); //load Obstacle Data	

		tiles = new int[mapSize, mapSize];
		//Initialize
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				tiles[x, y] = 1;

			}
		}


		//make obstacle
		for (int i = 0; i < size; i++) {
			tiles [(int)tilexy [0].obstacle [i].x, (int)tilexy [0].obstacle [i].y] = 3; //setting Obstacle 
		}
	
		tiles [4, 0] = 0; //start point 
		tiles [8, 4] = 0;
		tiles [0, 4] = 0;
		tiles [4, 8] = 0;

		tiles [0, 0] = 4; //warp point 
		tiles [8, 0] = 4;
		tiles [0, 8] = 4;
		tiles [8, 8] = 4;

		tiles[4, 4] = 2; //end point

	}

	void Update(){

		if (CountUp) {
			ObstacleCount = ObstacleCount + 1;
			Debug.Log ("Obstacle : " + ObstacleCount);

			DestoryAllTile ();  //you should remap 
			GenerateMapData (ObstacleCount);
			GenerateMapVisual ();

			CountUp = false;
		}
	}

	void loadObstacle(){
		tilexy = GameObject.Find("GameObject").GetComponents<tileXY>();

	}

	public int getTileData(int x,int y){
       	int data = (int)tiles[x,y];
		return data; //GetTile
	}            



	void GenerateMapVisual(){
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				TileType tile = tiletypes [tiles [x, y]];
				GameObject go = (GameObject)Instantiate (tile.tileViualPrefab, new Vector3(x,0,y),Quaternion.identity);
				ct = go.GetComponent<ClickableTile> ();
				ct.tileX = x;
				ct.tileY = y;
				ct.map = this;
			}
		}
	}
		

	public void DestoryAllTile(){
			//Destory all Tiles
			Tiles = GameObject.FindGameObjectsWithTag ("Tile");
			for(var i = 0 ; i < Tiles.Length ; i ++)
			{
				Destroy(Tiles[i]);
			}
	}
		



	public void TileBuilder(string name){
		//remake Tile with this method
		//Debug.Log (ObstacleCount);

		if (name == "First") {

			//Debug.Log ("P1_ObstacleCount : " + P1_ObstacleCount);
		
			if (P1_ObstacleCount >= 7) {
				Debug.Log ("End!");

				ObstacleCount = ObstacleCount - 8;
				P1_ObstacleCount = 0;

				//Debug.Log (ObstacleCount);

				//reset P1_Obstacle
				for (int i = 0; i < tilexy[0].obstacle.Length ; i++) {
					for (int j = 0; j < tilexy [0].Player1Obstacle.Length; j++) {

						if (tilexy [0].obstacle [i].x == tilexy [0].Player1Obstacle [j].x && tilexy [0].obstacle [i].y == tilexy [0].Player1Obstacle [j].y) {
							Debug.Log ("Delete Previous Data");
							tilexy [0].obstacle [i].x = 10;
							tilexy [0].obstacle [i].y = 10;


						}
					}
				}

				MakeShuffle (Player1_ObstacleCount);

				CountUp = true;


			} else {
				
				tilexy [0].obstacle [ObstacleCount].x = tilexy [0].Player1Obstacle [Player1_ObstacleCount [P1_ObstacleCount]].x;
				tilexy [0].obstacle [ObstacleCount].y = tilexy [0].Player1Obstacle [Player1_ObstacleCount [P1_ObstacleCount]].y;


				P1_ObstacleCount++; //P1's Obstacle Count increase 
				CountUp = true;
			}



		} else if (name == "Second") {

			if (P2_ObstacleCount >= 7) {
				Debug.Log ("End!");

				ObstacleCount = ObstacleCount - 8;
				P2_ObstacleCount = 0;

				//Debug.Log (ObstacleCount);

				//reset P1_Obstacle
				for (int i = 0; i < tilexy[0].obstacle.Length ; i++) {
					for (int j = 0; j < tilexy [0].Player2Obstacle.Length; j++) {

						if (tilexy [0].obstacle [i].x == tilexy [0].Player2Obstacle [j].x && tilexy [0].obstacle [i].y == tilexy [0].Player2Obstacle [j].y) {
							Debug.Log ("Delete Previous Data");
							tilexy [0].obstacle [i].x = 10;
							tilexy [0].obstacle [i].y = 10;


						}
					}
				}

				MakeShuffle (Player2_ObstacleCount);

				CountUp = true;


			} else {

				tilexy [0].obstacle [ObstacleCount].x = tilexy [0].Player2Obstacle [Player2_ObstacleCount [P2_ObstacleCount]].x;
				tilexy [0].obstacle [ObstacleCount].y = tilexy [0].Player2Obstacle [Player2_ObstacleCount [P2_ObstacleCount]].y;


				P2_ObstacleCount++; //P1's Obstacle Count increase 
				CountUp = true;
			}

		} 
			
	}

	public void Set_Shuffle(int [] arr){
		for (int t = 0; t < arr.Length; t++) {
			int tmp = arr [t];
			int r = Random.Range (t, arr.Length);
			arr [t] = arr [r];
			arr [r] = tmp;
		}
	}

	void MakeShuffle(int [] arr){
	
		for (int i = 0; i < arr.Length; i++) {
			arr [i] = i;
		}

		Set_Shuffle(arr);

		for (int i = 0; i < arr.Length; i++) {
			Debug.Log ("Shuffle : " + arr [i]);
		}
	
	}

	//Player's crash and Player movement 


}
