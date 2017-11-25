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
            //print("EXIT SPAM EXIT SPAM!");
            //Destroy(collision.gameObject);
        }
    }
}
