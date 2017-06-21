using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {

	public int tileX;
	public int tileY;
	public MapMaking map;


	void OnMouseUp(){
		Debug.Log ("KEY MOVED!");
		map.MoveSelectedUnitTo (tileX, tileY);

	}
}
