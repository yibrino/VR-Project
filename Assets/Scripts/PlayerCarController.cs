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
                // presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
        presentAcceleration = accelerationForce * SimpleInput.GetAxis("Vertical");


        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;

    }
    private void CarSteering()
    {
        // presentTurnAngle=wheelsTorque*Input.GetAxis("Horizontal");
        presentTurnAngle=wheelsTorque*SimpleInput.GetAxis("Horizontal");

        frontLeftWheelCollider.steerAngle= presentTurnAngle;
    
        frontRightWheelCollider.steerAngle=presentTurnAngle;
        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRightWheelTransform);
    }

    void SteeringWheels(WheelCollider WC, Transform WT)
{
    Vector3 position;
    Quaternion rotation;

    WC.GetWorldPose(out position, out rotation);

    WT.position = position;
    WT.rotation = rotation;
}
public void ApplyBreaks()
{
    StartCoroutine(CarBreaks());
}

private IEnumerator CarBreaks()
{
    // Apply brake
    presentBreakForce = breakingForce;

    frontLeftWheelCollider.brakeTorque  = presentBreakForce;
    frontRightWheelCollider.brakeTorque = presentBreakForce;
    backLeftWheelCollider.brakeTorque   = presentBreakForce;
    backRightWheelCollider.brakeTorque  = presentBreakForce;

    yield return new WaitForSeconds(2f);

    // Release brake
    presentBreakForce = 0f;

    frontLeftWheelCollider.brakeTorque  = presentBreakForce;
    frontRightWheelCollider.brakeTorque = presentBreakForce;
    backLeftWheelCollider.brakeTorque   = presentBreakForce;
    backRightWheelCollider.brakeTorque  = presentBreakForce;
}


}
