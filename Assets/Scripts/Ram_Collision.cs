﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ram_Collision : MonoBehaviour {

    PlayerScript player;
    public static bool shouldCheckTriggerExit = true;

    void Start()
    {
        player = transform.parent.GetComponent<PlayerScript>();
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            //SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBump);
            //Reduce Speed
            player.ReduceSpeed();
        }
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (shouldCheckTriggerExit)
        {
            switch (player.PlayerTag)
            {
                case PlayerType.LEFT:
                    if (col.gameObject.tag == "RIGHT_AGENT")
                    {
                        // Do a speed comparison
                        //print("Doing Speed Comparision");
                        player.SpeedComparision(col.gameObject.GetComponent<PlayerScript>());
                    }

                    break;
                case PlayerType.RIGHT:
                    if (col.gameObject.tag == "LEFT_AGENT")
                    {
                        // Do a speed comparison
                        //print("Doing Speed Comparision");
                        player.SpeedComparision(col.gameObject.GetComponent<PlayerScript>());
                    }

                    break;
            }
        }
    }
}
