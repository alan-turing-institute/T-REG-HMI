using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRightLeg : MonoBehaviour
{
    protected HingeJoint jointController;

    public GameObject right_thigh;
    public float move=1000;

    private Vector3 position;
    private float velocity;
    private int frameCount;
    private float force;
    private float targetVelocity;

    // Start is called before the first frame update
    void Start()
    {
        jointController = right_thigh.GetComponent<HingeJoint>();
        var motor = jointController.motor;
        targetVelocity = 0;
        motor.targetVelocity = targetVelocity;
        force = 1e10f;
        motor.force = force;
        motor.freeSpin = false;
        jointController.motor = motor;
        jointController.useMotor = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("p")) {
            MoveLeg(move);
        }
        else if (Input.GetKey("o")) {
            MoveLeg(-move);
        }
        else {
            var motor = jointController.motor;
            targetVelocity = 0;
            motor.targetVelocity = targetVelocity;
            jointController.motor = motor;
        }
    }

    public void MoveLeg(float targetVelocity) {
        var motor = jointController.motor;
        motor.targetVelocity = targetVelocity;
        jointController.motor = motor;   
        return;
    }

}