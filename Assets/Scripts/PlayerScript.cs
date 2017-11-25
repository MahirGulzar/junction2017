using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PlayerType
{
    LEFT,
    RIGHT,
}


public class PlayerScript : MonoBehaviour {

	public float initial_speed;
    public float current_speed;
    public float acceleration;
    public float speed_factor;
    Rigidbody2D rb;
    public PlayerType PlayerTag;
    private float sliderValue=0.5f;
    private int rotateFactor = 0;
    

	// Use this for initialization
	void Start () {
        current_speed = initial_speed;
	}
	
	// Update is called once per frame
	void Update () {
        current_speed += acceleration * Time.deltaTime;
        transform.position += transform.right * current_speed * Time.deltaTime;

        if (sliderValue > 0.5f)
            rotateFactor = 1;
        else if (sliderValue < 0.5f)
            rotateFactor = -1;
        else
            rotateFactor = 0;

        float diff = Mathf.Abs(sliderValue - 0.5f);
        diff *= 200;
        transform.Rotate(0, 0, diff * (float)rotateFactor * Time.deltaTime);
    }


    public void OnSliderValueChange(Slider slider)
    {
        print("Player " + gameObject.name + " should rotate with this");
        sliderValue = slider.value;
    }
       
}
