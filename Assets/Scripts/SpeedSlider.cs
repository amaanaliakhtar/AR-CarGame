using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpeedSlider : MonoBehaviour
{
    private Slider speedSlider;
    private GameObject car;
    public float speedMinValue;
    public float speedMaxValue;

    void Start()
    {
        speedSlider = GameObject.Find("SpeedSlider").GetComponent<Slider>();
        speedSlider.minValue = speedMinValue;
        speedSlider.maxValue = speedMaxValue;
    }
    void SpeedSliderUpdate(float value)
    {
        car = (GameObject)Resources.Load("Prefabs/Car", typeof(GameObject));
        car.FixedUpdate();
    }
}