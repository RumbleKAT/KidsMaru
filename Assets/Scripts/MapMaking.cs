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

	private int Player1_ObstacleCount = 1;
	private int Player2_ObstacleCount = 1;
	private int Player3_ObstacleCount = 1;
	private int Player4_ObstacleCount = 1;


	void Start () {

		ObstacleCount = 4; //total counting 
		GenerateMapData (ObstacleCount);
		GenerateMapVisual();
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

		Debug.Log (ObstacleCount);

		if (name == "First") {
			 
			//each player can make obstacle 8. 

			int selection = Random.Range (0, 7); //min value: 0 | max value: 6
			//exception 


			Debug.Log ("X location : " + tilexy[0].Player1Obstacle[selection].x + " | " + "Y location : " + tilexy[0].Player1Obstacle[selection].y  );

			if (tilexy [0].Player1Obstacle [selection].x == 10 && tilexy [0].Player1Obstacle [selection].y == 10) {

				selection = Random.Range (0, 7); //Player's location compare needed

				Debug.Log (selection);

			} else {
				tilexy [0].obstacle [ObstacleCount].x = tilexy [0].Player1Obstacle [selection].x;
				tilexy [0].obstacle [ObstacleCount].y = tilexy [0].Player1Obstacle [selection].y;

				tilexy [0].Player1Obstacle [selection].x = 10;
				tilexy [0].Player1Obstacle [selection].y = 10;


				CountUp = true;
			
			}

		}
			
	}




}
