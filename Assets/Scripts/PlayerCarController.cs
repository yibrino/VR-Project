using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;
    [Header("Car Steering")]
    public float wheelsTorque=35f;
    public float presentTurnAngle=0f;




    private void Update()
    {
        MoveCar();
        CarSteering();
    }

    private void MoveCar()
    {
        //FWD
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    }
    private void CarSteering()
    {
        presentTurnAngle=wheelsTorque*Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle= presentTurnAngle;
        frontRightWheelCollider.steerAngle=presentTurnAngle;
    }
}
