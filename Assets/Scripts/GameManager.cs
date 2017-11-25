using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    private float currentTime;

    public float roundCountDownLength;

    public int numRoundsToWinForVictory;

    public PlayerScript leftPlayer;
    public PlayerScript rightPlayer;

    public Text timerText;

    private bool playerTimersSet = false;

    void Start()
    {
        currentTime = 0.0f;
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
        Debug.Log("Next round requested!");
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
