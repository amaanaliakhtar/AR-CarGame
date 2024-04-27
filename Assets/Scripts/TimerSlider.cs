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
        gameOverText.gameObject.SetActive(false);

        timerSlider = GameObject.FindGameObjectWithTag("TimerSlider").GetComponent<Slider>();
        timerText = GameObject.FindGameObjectWithTag("TimerText").GetComponent<TextMeshProUGUI>();

        fillImage = GameObject.FindGameObjectWithTag("SliderFill").GetComponent<Image>();

        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        fillImage.color = normalFillColor;



    }


    void Update()
    {
        gameTime -= Time.deltaTime;

        string textTime = "Time left: " + gameTime.ToString("f0") + "s";

        if (stopTimer == false)
        {
            timerText.text = textTime;
            timerSlider.value = gameTime;
        }

        if (timerSlider.value < ((warningLimit / 100) * timerSlider.maxValue))
        {
            fillImage.color = warningFillColor;
        }

        if (gameTime <= 0 && stopTimer == false)  // On Game over
        {
            stopTimer = true;
            Destroy(timerSlider.gameObject);
            gameOverText.gameObject.SetActive(true);

            GameObject[] gems = GameObject.FindGameObjectsWithTag("Gem");
            foreach (GameObject gem in gems)
                Destroy(gem);

        }





    }
}

