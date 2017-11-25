using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_Follow : MonoBehaviour {

    public Transform toFollow;
	
	// Update is called once per frame
	void Update () {
        if(toFollow!=null)
            this.transform.position = toFollow.transform.position;
	}
}
