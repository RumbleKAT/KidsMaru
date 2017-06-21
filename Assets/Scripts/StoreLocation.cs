using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StoreLocation {
	//STORE before location 
	private Vector2 location;

	public float getX(){
		return this.location.x;
	}

	public float getY(){
		return this.location.y;
	}

	public void setX(int x){
		this.location.x = x;
	}
	public void setY(int y){
		this.location.y = y;
	}
}
