using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {

	public int tileX;
	public int tileY;
	public MapMaking map;


	void Start(){
		tileX = 0;
		tileY = 0;


	}

	void Update(){

		move ();

	}


	void move(){

		if (tileX < 0) {
			Debug.Log ("away from land2");
			tileX = 0; 
		} else if (tileY < 0) {
			tileY = 0;
		} else if (tileX > 9) {
			tileX = 9;
		} else if (tileY > 9) {
			tileY = 9;
		}
			

		if (Input.GetKeyDown (KeyCode.W)) {
			map.MoveSelectedUnitTo (tileX, ++tileY);
		} 
		else if (Input.GetKeyDown (KeyCode.S)) 
		{
			map.MoveSelectedUnitTo (tileX, --tileY);
		} else if (Input.GetKeyDown (KeyCode.A)) 
		{
			map.MoveSelectedUnitTo (--tileX, tileY);
		} else if (Input.GetKeyDown (KeyCode.D)) 
		{
			map.MoveSelectedUnitTo (++tileX, tileY);
		}
	
	}
}
