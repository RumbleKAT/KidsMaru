using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause1 : MonoBehaviour {
    //How many seconds do we wait?
    public float waitTime = 3.0f;
    //Timer counter
    private float timer;
    //Is the timer active?
     private bool timerActive = false;
    //Is the button active?
    public bool buttonActive = false;

	public byte [] Player1_order; 
	public GameObject Player1;
	bool Player1_move;
	bool check = false;
	PlayerControl P1;

	int count = 0; 
	int i = 0;

	void Start(){

		Player1_order = new byte[8];
		Player1_move = false;
		P1 = Player1.GetComponent<PlayerControl> ();

	}

     void Update()
    {

		if (Input.GetKeyDown (KeyCode.M)) {
			check = true;
		}


        //If event happends, for now a button, but can be whatever you want
        if (check)
        {
            //Debug.Log(i);
            //We want the timer to start counting
            timerActive = true;
            //Button to be active
            buttonActive = true;

        }


        
     //If the timer is active
     if (timerActive)
        {
            if (i > 7)
            {
                i = 0;

                buttonActive = false;
                //The timer stops
                timerActive = false;
                //Reset the timer
                timer = 0.0f;

                check = false;
                i = 0;
            }
            //Add seconds to the counter
            timer += 1 * Time.deltaTime;

            //If the timer is greater than the time we want to wait
            if (timer > waitTime)
            {
                //Debug.Log("Time Over!");
				load_Data (i);
				i++;

               //The button is no longer active
                buttonActive = false;
                //The timer stops
                timerActive = false;

                check = true;
                //Reset the timer
                timer = 0.0f;
            }
        }
    }


	void load_Data(int i){

		if (i > 8) {
			Player1_move = false;	
			Debug.Log ("The End!");
		}

		if (count == 8) {
			P1.reset = true;
			P1.getCurrentLocation ();
			P1.locationCheck = false;

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
