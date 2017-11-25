﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    private float currentTime;

    public float roundCountDownLength;
    public int numRoundsToWinForVictory;

    public PlayerScript leftPlayer;
    public PlayerScript rightPlayer;
    public int left_win_Count = 0;
    public int right_win_Count = 0;

    public Text timerText;
    private bool playerTimersSet = false;

    public Action<PlayerType> onResetEvent;
    


    
    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        onResetEvent += this.OnResetBattle;
    }
    private void OnDisable()
    {
        onResetEvent -= this.OnResetBattle;
    }
    void Start()
    {
        currentTime = 0.0f;
    }


    void OnResetBattle(PlayerType playerType)
    {
        TriggerExit.shouldCheckTriggerExit = false;

        leftPlayer.transform.position = leftPlayer.spawnPos;
        leftPlayer.gameObject.SetActive(true);
        leftPlayer.UI_Speed.gameObject.SetActive(true);
        leftPlayer.transform.rotation = leftPlayer.spawnRotation;
        leftPlayer.timeFactor = 0;
        leftPlayer.current_speed = leftPlayer.initial_speed;

        rightPlayer.transform.position = rightPlayer.spawnPos;
        rightPlayer.gameObject.SetActive(true);
        rightPlayer.transform.rotation = rightPlayer.spawnRotation;
        rightPlayer.UI_Speed.gameObject.SetActive(true);
        rightPlayer.timeFactor = 0;
        rightPlayer.current_speed = rightPlayer.initial_speed;

        switch (playerType)
        {
            case PlayerType.LEFT:
                left_win_Count++;
                if(left_win_Count>=3)
                {

                    return;
                }
                break;
            case PlayerType.RIGHT:
                right_win_Count++;
                if (right_win_Count >= 3)
                {

                    return;
                }
                break;
            case PlayerType.None:
                // Draw
                break;
        }
        // Reset Game
        currentTime = 0;
        playerTimersSet = false;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (timerText)
        {
            float timeDelta = roundCountDownLength - currentTime;

            if (timeDelta > 0.0f)
            {
                timerText.text = ((int)(timeDelta) + 1).ToString();
            }
            else if (!playerTimersSet && timeDelta < 0.01f)
            {
                playerTimersSet = true;
                TriggerExit.shouldCheckTriggerExit = true;
                if (leftPlayer)
                    leftPlayer.timeFactor = 1;
                if (rightPlayer)
                    rightPlayer.timeFactor = 1;
            }
            else if (timeDelta > -2.0f)
            {
                timerText.text = "GO!";
            }
            else
            {
                timerText.text = "";
            }
        }
    }

    private void startNextRound()
    {
        //Debug.Log("Next round requested!");
        currentTime = 0.0f;

        // reset level
    }

    private void GameOver()
    {
        Debug.Log("Game Over requested!");
        SceneManager.LoadScene("MainMenu");
    }

    public void OnSliderUp(Slider slider)
    {
        slider.value = 0.5f;
    }



}
