using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crash : MonoBehaviour {

    public GameObject Player;
    private string [] PlayingTag;
    private PlayerControl p1;
//    private Player2Control p2;

    // Use this for initialization
    void Start () {

    }

    void Awake()
    {
        //Player's lastX, lastY need loaded
        getPlayingTag();
    }


    // Update is called once per frame
    void Update () {

    }

    void getPlayingTag()
    {
        PlayingTag = new string [3];
        //getPlayer's tag 


        if(Player.gameObject.tag == "Player")
        {
            //Player1 is selected
           // Debug.Log("Player1 is selected");

            PlayingTag[0] = "Player2";
            PlayingTag[1] = "Player3";
            PlayingTag[2] = "Player4";

            p1 = Player.GetComponent<PlayerControl>();
           // Debug.Log("Player1 LastX : " + p1.lastx);

        }
        else if(Player.gameObject.tag == "Player2")
        {
            //  Debug.Log("Player2 is selected");


            PlayingTag[0] = "Player1";
            PlayingTag[1] = "Player3";
            PlayingTag[2] = "Player4";

            //p2 = Player.GetComponent<Player2Control>();
        }
        else if(Player.gameObject.tag == "Player3")
        {
            //  Debug.Log("Player3 is selected");

            PlayingTag[0] = "Player1";
            PlayingTag[1] = "Player2";
            PlayingTag[2] = "Player4";


        }
        else if(Player.gameObject.tag == "Player4")
        {
            //            Debug.Log("Player4 is selected");

            PlayingTag[0] = "Player1";
            PlayingTag[1] = "Player2";
            PlayingTag[2] = "Player3";

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        for(int i = 0; i < PlayingTag.Length; i++)
        {
            if (other.gameObject.tag == PlayingTag[i])
            {
                Debug.Log("crash!");
                if (Player.gameObject.tag == "Player")
                {
                    //p1.action = false;
                    //transform.position = new Vector3((int)p1.lastx, 1, (int)p1.lasty);
                    p1.crashing = true;
                    Debug.Log("crashing :" + p1.crashing);
                }
            }
        }
      
    }
}
