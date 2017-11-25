using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum PlayerType
{
    LEFT,
    RIGHT,
}


public class PlayerScript : MonoBehaviour
{
    [Header("Tweakers")]
    [Space(10)]
    public float initial_speed;
    public float current_speed;
    public float acceleration;
    [Space(10)]
    [Range(0,100)]
    public int reduce_factor;


    [Header("Differentiator")]
    [Space(10)]
    public PlayerType PlayerTag;
    private float sliderValue = 0.5f;
    private int rotateDirection = 0;


    [Header("UI Elements")]
    [Space(10)]
    public Text UI_Speed;

    // Use this for initialization
    void Start()
    {
        current_speed = initial_speed;
    }

    // Update is called once per frame
    void Update()
    {
        
        current_speed += acceleration * Time.deltaTime;
        transform.position += transform.right * current_speed * Time.deltaTime;

        if (sliderValue > 0.5f)
            rotateDirection = -1;
        else if (sliderValue < 0.5f)
            rotateDirection = 1;
        else
            rotateDirection = 0;

        float diff = Mathf.Abs(sliderValue - 0.5f);
        diff *= 200;
        transform.Rotate(0, 0, diff * (float)rotateDirection * Time.deltaTime);
        UI_Speed.text = ((int)current_speed).ToString();
    }


    public void OnSliderValueChange(Slider slider)
    {
        print("Player " + gameObject.name + " should rotate with this");
        sliderValue = slider.value;
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag=="Obstacle")
        {
            //Reduce Speed
            ReduceSpeed();
        }
        
    }



    public void ReduceSpeed()
    {
        float factor = (float)((current_speed / 100) * (float)reduce_factor);
        Debug.Log(factor + " to be reduced");
        float check_min = current_speed - factor;
        if(!(check_min<initial_speed))
        {
            current_speed -= factor;
        }
    }



    public void SpeedComparision(PlayerScript otherPlayer)
    {
        if(otherPlayer.gameObject!=null)
            if((int)otherPlayer.current_speed < (int)(current_speed))
            {
                otherPlayer.UI_Speed.gameObject.SetActive(false);
                Destroy(otherPlayer.gameObject);
            }
    }
}
