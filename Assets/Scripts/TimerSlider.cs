using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerSlider : MonoBehaviour
{

    Slider timerSlider;
    TextMeshProUGUI timerText;

    public float gameTime = 20.0f;

    Image fillImage;
    public Color32 normalFillColor;
    public Color32 warningFillColor;
    public float warningLimit;  // as a percentage

    public bool stopTimer;

    TextMeshProUGUI gameOverText;
    void Start()
    {
        stopTimer = false;

        gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<TextMeshProUGUI>();
        gameOverText.gameObject.SetActive(false); //game over text should be hidden at start

        timerSlider = GameObject.FindGameObjectWithTag("TimerSlider").GetComponent<Slider>();
        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();

        fillImage = GameObject.FindGameObjectWithTag("SliderFill").GetComponent<Image>();

        timerSlider.maxValue = gameTime;  
        timerSlider.value = gameTime;   // start timer length at maximum time

        fillImage.fillAmount = gameTime;
        fillImage.color = normalFillColor;  // time colour green at start
    }


    void Update()
    {
        gameTime -= Time.deltaTime; // begin reducing the time

        string textTime = "Time left: " + gameTime.ToString("f0") + "s";    // update the displayed text on the timer

        if (stopTimer == false)
        {
            // while the timer is not at 0 keep updating the timer value and display value
            timerText.text = textTime;
            timerSlider.value = gameTime;
        }

        if (timerSlider.value < ((warningLimit / 100) * timerSlider.maxValue))
        {
            // when the timer reaches the warning limit change its colour to red
            fillImage.color = warningFillColor;
        }

        if (gameTime <= 0 && stopTimer == false)  // on Game over
        {
            stopTimer = true;
            Destroy(timerSlider.gameObject);
            gameOverText.gameObject.SetActive(true);

            // remove all gems from the ar gam
            GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
            foreach (GameObject gem in gems)
                Destroy(gem);

        }





    }
}

