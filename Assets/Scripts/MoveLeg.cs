using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeg : MonoBehaviour
{
    protected HingeJoint jointController;


    public float move=1000;

    private Vector3 position;
    private float velocity;
    private int frameCount;
    private float force;
    private float targetVelocity;

    // Start is called before the first frame update
    void Start()
    {
        jointController = GetComponent<HingeJoint>();
        var motor = jointController.motor;
        targetVelocity = 0;
        motor.targetVelocity = targetVelocity;
        force = 1e10f;
        motor.force = force;
        motor.freeSpin = false;
        jointController.motor = motor;
        jointController.useMotor = true;
    }

   

    public void MoveLegForwards() {
        targetVelocity = move;
        var motor = jointController.motor;
        motor.targetVelocity = targetVelocity;
        jointController.motor = motor;   
        return;
    }

    public void MoveLegBackwards() {
        targetVelocity = -1*move;
        var motor = jointController.motor;
        motor.targetVelocity = targetVelocity;
        jointController.motor = motor;   
        return;
    }

    public void StopLeg() {
        var motor = jointController.motor;
        targetVelocity = 0;
        motor.targetVelocity = targetVelocity;
        jointController.motor = motor;
    }

}