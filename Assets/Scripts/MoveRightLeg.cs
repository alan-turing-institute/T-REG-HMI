using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeg : MonoBehaviour
{
    protected HingeJoint jointController;

    public GameObject right_thigh;
    public float move;

    private Vector3 position;
    private float velocity;
    private int frameCount;
    private float force;
    private float targetVelocity;

    // Start is called before the first frame update
    void Start()
    {
        jointController = right_thigh.GetComponent<HingeJoint>();
        if (jointController == null) print("Couldn't find HingeJoint");
        else print("Got a joint controller");
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
        
        if (Input.GetKey("w")) {
            MoveLeg(move);
        }
        else if (Input.GetKey("q")) {
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
        print("OPEN  "+jointController.velocity);
        return;
    }

}