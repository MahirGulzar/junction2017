using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour {

    public static bool shouldCheckTriggerExit = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (shouldCheckTriggerExit)
        {
            if (collision.gameObject.tag == "LEFT_AGENT"
                || collision.gameObject.tag == "RIGHT_AGENT")
            {

                print("fucking horrible");
                if (collision.gameObject.GetComponent<PlayerScript>() != null)
                {
                    PlayerScript temp = collision.gameObject.GetComponent<PlayerScript>();
                    temp.particle.startColor = new Color32(0, 191, 255, 255);


                }
                //{
                //    collision.gameObject.GetComponent<PlayerScript>().UI_Speed.gameObject.SetActive(false);
                //    collision.gameObject.SetActive(false);
                //if (collision.gameObject.GetComponent<PlayerScript>() != null)
                //{
                //    collision.gameObject.GetComponent<PlayerScript>().UI_Speed.gameObject.SetActive(false);
                //    collision.gameObject.SetActive(false);


                //    if (collision.tag == "LEFT_AGENT")
                //    {
                //        GameManager.Instance.onResetEvent(PlayerType.RIGHT);
                //        Debug.Log("Left Player Fell in Water..");

                //    }
                //    else
                //    {
                //        GameManager.Instance.onResetEvent(PlayerType.LEFT);
                //        Debug.Log("Right Player Fell in Water..");
                //    }
                //}

            }
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (shouldCheckTriggerExit)
        {
            if (collision.gameObject.tag == "LEFT_AGENT"
                || collision.gameObject.tag == "RIGHT_AGENT")
            {


                if (collision.gameObject.GetComponent<PlayerScript>() != null)
                {
                    PlayerScript temp = collision.gameObject.GetComponent<PlayerScript>();
                    temp.particle.startColor = new Color32(255, 255, 255, 255);
                    //temp.particle.startColor = new Color32(176, 224, 230, 255);
                    //176,224,230

                }
                //{
                //    collision.gameObject.GetComponent<PlayerScript>().UI_Speed.gameObject.SetActive(false);
                //    collision.gameObject.SetActive(false);
                //if (collision.gameObject.GetComponent<PlayerScript>() != null)
                //{
                //    collision.gameObject.GetComponent<PlayerScript>().UI_Speed.gameObject.SetActive(false);
                //    collision.gameObject.SetActive(false);


                //    if (collision.tag == "LEFT_AGENT")
                //    {
                //        GameManager.Instance.onResetEvent(PlayerType.RIGHT);
                //        Debug.Log("Left Player Fell in Water..");

                //    }
                //    else
                //    {
                //        GameManager.Instance.onResetEvent(PlayerType.LEFT);
                //        Debug.Log("Right Player Fell in Water..");
                //    }
                //}

            }
        }
    }
}
