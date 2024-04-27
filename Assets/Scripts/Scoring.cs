using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameObject scoreboardUI;
    public static int scoreValue;

    private void Start()
    {
        scoreboardUI = GameObject.FindGameObjectWithTag("ScoreboardCanvas");
        scoreText = GameObject.FindGameObjectWithTag("ScoreDisplay").GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        scoreText.text = "Score: " + scoreValue.ToString();
    }
}
