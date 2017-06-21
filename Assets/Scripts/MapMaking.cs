using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaking : MonoBehaviour {

	public GameObject selectedUnit;
	public TileType [] tiletypes;
	int[,] tiles;

	public int mapSize = 10;
	private Vector2 LastLocation;
	ClickableTile ct;

	void Start () {
		
		GenerateMapData ();
		GenerateMapVisual();

	}

	void GenerateMapData(){
	
		tiles = new int[mapSize, mapSize];
		//Initialize
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				tiles[x, y] = 1;
			}
		}
		tiles[0, 0] = 0;
		tiles[1, 0] = 3; //obstacle 
		tiles[4, 4] = 2;
		tiles[5, 4] = 2;
		tiles[6, 4] = 2;
		tiles[7, 4] = 2;
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
		
	//make shape
	public void MoveSelectedUnitTo(int x, int y){

		Debug.Log ("x location : " + (int)(LastLocation.x));
		Debug.Log ("y location : " + (int)(LastLocation.y));


		if (x < 0 || y < 0) {
			Debug.Log ("away from land");
			x = (int)(LastLocation.x); 
			y = (int)(LastLocation.y);
		} else if (x > 10 || y > 10) {
			x = (int)(LastLocation.x); 
			y = (int)(LastLocation.y);
		} //exception
			
			TileType tile = tiletypes [tiles [x, y]];

			if (tile.objname == "Obstacle") {
				Debug.Log ("This is Obstacle!");
				
				ct.tileX = (int)LastLocation.x;
				ct.tileY = (int)LastLocation.y;

			x = (int)(LastLocation.x); 
			y = (int)(LastLocation.y);

			Debug.Log ("x location : " + x);
			Debug.Log ("y location : " + y);


			selectedUnit.transform.position = new Vector3 (x, 0.8f, y);

			} else if (tile.objname == "Start") {
				selectedUnit.transform.position = new Vector3 (x, 0.8f, y);
				x = (int)(LastLocation.x); 
				y = (int)(LastLocation.y);
				Debug.Log ("Start!");
			} else if (tile.objname == "End") {
				selectedUnit.transform.position = new Vector3 (x, 0.8f, y);
				x = (int)(LastLocation.x); 
				y = (int)(LastLocation.y);
				Debug.Log ("End!");
			} else {
				LastLocation.x = x;
				LastLocation.y = y;
				selectedUnit.transform.position = new Vector3 (x, 0.8f, y);
			}
	}
}
