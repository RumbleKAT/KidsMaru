using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

	public TileType[] tileTypes;
	public Transform tilePrefab;
	public int mapSize;

	int [,] tilesData;

	[Range(0,1)]
	public float outlinePercent;


	void Start(){
		GeneratorMap ();
	}


	public void GeneratorMap(){


	//allocate
		tilesData = new int[mapSize, mapSize];


		//Initialize
		for (int x = 0; x < mapSize; x++) {
			for (int y = 0; y < mapSize; y++) {
				Vector3 tilePosition = new Vector3 (-mapSize / 2 + 0.5f + x, 0, -mapSize/2 + 0.5f + y);
				Transform newTile = Instantiate (tilePrefab, tilePosition, Quaternion.Euler (Vector3.right * 90)) as Transform;
				newTile.localScale = Vector3.one * (1-outlinePercent);
			}
		}
	
	}
}
