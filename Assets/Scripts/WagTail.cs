using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagTail : MonoBehaviour
{
    protected HingeJoint[] jointController;

    private GameObject tail_1;
    private GameObject tail_2;
    private GameObject tail_3;
    private GameObject tail_3_end;
    public float move=50;

    private Vector3 position;
    private float velocity;
    private int frameCount;
    private float force;
    private float targetVelocity;

    // Start is called before the first frame update
    void Start()
    {
        tail_1 = GameObject.Find("tail_1");
        tail_2 = GameObject.Find("tail_2");
        tail_3 = GameObject.Find("tail_3");
        tail_3_end = GameObject.Find("tail_3_end");
        
        jointController = new HingeJoint[] {
            tail_1.GetComponent<HingeJoint>(),
            tail_2.GetComponent<HingeJoint>(), 
            tail_3.GetComponent<HingeJoint>(), 
            tail_3_end.GetComponent<HingeJoint>()};

        foreach (HingeJoint joint in jointController){
            var motor = joint.motor;
            targetVelocity = 0;
            motor.targetVelocity = targetVelocity;
            force = 1e10f;
            motor.force = force;
            motor.freeSpin = false;
            joint.motor = motor;
            joint.useMotor = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("f")) {
            MoveTail(move);
        }
        else if (Input.GetKey("d")) {
            MoveTail(-move);
        }
        else {
            MoveTail(0f);
        }
    }

    public void MoveTail(float targetVelocity) {
        foreach (HingeJoint joint in jointController){
            var motor = joint.motor;
            motor.targetVelocity = targetVelocity;
            joint.motor = motor;
            }
        return;
    }

}