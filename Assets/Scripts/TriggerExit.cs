using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LEFT_AGENT"
            || collision.gameObject.tag == "RIGHT_AGENT")
        {
            if(collision.tag== "LEFT_AGENT")
            {
                GameManager.Instance.onResetEvent(PlayerType.LEFT);
                Debug.Log("Left Player Fell in Water..");
                
            }
            else
            {
                GameManager.Instance.onResetEvent(PlayerType.RIGHT);
                Debug.Log("Right Player Fell in Water..");
            }
            collision.gameObject.SetActive(false);
        }
    }
}
