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
    public float speed_factor;
    Rigidbody2D rb;
    public PlayerType PlayerTag;
    private float sliderValue=0.5f;
    private float rotateFactor = 0;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.right * initial_speed * Time.deltaTime;
        
        switch (PlayerTag)
        {
            case PlayerType.LEFT:
                if (sliderValue > 0.5)
                {
                    print("Rotate Right");
                    rotateFactor = +1f;
                }
                else if (sliderValue < 0.5)
                {
                    print("Rotate Left");
                    rotateFactor = -1f;
                }
                else
                {
                    print("No Rotation");
                    rotateFactor = 0;
                }
                break;

            case PlayerType.RIGHT:
                if (sliderValue > 0.5)
                {
                    print("Rotate Left");
                    rotateFactor = +1f;
                }
                else if (sliderValue < 0.5)
                {
                    print("Rotate Right");
                    rotateFactor = -1f;
                }
                else
                {
                    print("No Rotation");
                    rotateFactor = 0;
                }
                break;
        }

        float diff = Mathf.Abs(sliderValue - 0.5f);
        diff *= 200;
        transform.Rotate(0, 0, diff * rotateFactor * Time.deltaTime);
    }


    public void OnSliderValueChange(Slider slider)
    {
        print("Player " + gameObject.name + " should rotate with this");
        sliderValue = slider.value;
    }
       
}
