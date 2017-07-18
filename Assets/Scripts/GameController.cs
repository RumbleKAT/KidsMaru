using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public byte [] Player1_order; 
	public GameObject Player1;
	bool Player1_move;
	bool check = false;
	private int i = 3;


	PlayerControl P1;

	// Use this for initialization
	void Start () {
		
		Player1_order = new byte[11];
		Player1_move = false;
		P1 = Player1.GetComponent<PlayerControl> ();
			
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.M)) {
			Player1_move = true;	
		}

		if (Player1_move) {
			load_Data (i);
		}
			
	}

	void load_Data(int i){
		int count = 0;

		if (i > 8) {
			Player1_move = false;	
		}

			if (Player1_order [i] == 0) {
				count++;
				i++;
		
			} else if (Player1_order [i] == 1) {

				P1.up = true;
				P1.down = false;
				P1.left = false;
				P1.right = false;

				P1.getCurrentLocation ();
				P1.locationCheck = false;

				//HERE TURN P1 MOVEMENT CHECKING 


			} else if (Player1_order [i] == 2) {

				P1.up = false;
				P1.down = true;
				P1.left = false;
				P1.right = false;

				P1.getCurrentLocation ();
				P1.locationCheck = false;

				

			} else if (Player1_order [i] == 3) {

				P1.up = false;
				P1.down = false;
				P1.left = true;
				P1.right = false;

				P1.getCurrentLocation ();
				P1.locationCheck = false;


			} else if (Player1_order [i] == 4) {

				P1.up = false;
				P1.down = false;
				P1.left = false;
				P1.right = true;

				P1.getCurrentLocation ();
				P1.locationCheck = false;


			}

		i++;

	}


}
