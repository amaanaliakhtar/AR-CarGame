using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float userInput;
    private float hInput;
    private float vInput;
    private float currentBrakeForce;
    private bool isBraking;

    [SerializeField] private float engineForce = 3000;
    [SerializeField] private float brakeForce = 3000;

    private float currentSteerAngle;
    [SerializeField] private float maxSteerAngle = 30;

    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;

    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform backRightTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()  //This method is executed a fixed no. of times per frame
    {
        GetInput();
        Accelerate();
        Steering();
        UpdateVisuals();
    }

    public void UserInput(float input)
    {
        vInput = input;
    }

    private void GetInput()
    {

        //hInput = Input.GetAxis(HORIZONTAL);
        //vInput = Input.GetAxis(VERTICAL);
        //isBraking = Input.GetKey(KeyCode.Space);
    }

    private void Accelerate()
    {
        frontLeftCollider.motorTorque = vInput * engineForce;
        frontRightCollider.motorTorque = vInput* engineForce;

        if (isBraking)
        {
            currentBrakeForce = brakeForce;
            ApplyBraking();
        }
        else
        {
            currentBrakeForce = 0f;
        }
    }

    private void ApplyBraking()
    {
        frontLeftCollider.brakeTorque = currentBrakeForce;
        frontRightCollider.brakeTorque = currentBrakeForce;
        backLeftCollider.brakeTorque = currentBrakeForce;
        backRightCollider.brakeTorque = currentBrakeForce;
    }

    private void Steering()
    {
        currentSteerAngle = maxSteerAngle * hInput;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateVisuals()
    {
        UpdateWheel(frontLeftCollider, frontLeftTransform);
        UpdateWheel(frontRightCollider, frontRightTransform);
        UpdateWheel(backLeftCollider, backLeftTransform);
        UpdateWheel(backRightCollider, backRightTransform);
    }

    private void UpdateWheel(WheelCollider collider, Transform transform)
    {
        //Get the new wheel postion and apply to the visuals
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        transform.rotation = rotation;
        transform.position = position;
        
    }
}
