using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JawOpener : MonoBehaviour
{
    private GameObject bottomJaw;
    protected HingeJoint jointController;
    
    public float jawAngleClosed = 10.0f;
    public float jawAngleOpen = -60.0f;
    
    public float jawAngle = 0.0f;
    public float damping = 5.0f;
    public float springCoefficient = 200.0f;


    // Start is called before the first frame update
    void Start()
    {
        print("Starting JawOpener");

        bottomJaw = GameObject.Find("bottom_jaw");

        jointController = bottomJaw.GetComponent<HingeJoint>();
        jointController.useSpring = true;

        SetSpringParams(jawAngle, damping, springCoefficient);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown("z"))
        {
            jawAngle = jawAngleClosed;
        } 
        else if (Input.GetKeyDown("x"))
        {
            jawAngle = jawAngleOpen;
        }
        */
        SetSpringParams(jawAngle, damping, springCoefficient);
    }

    public void OpenJaw() {
        jawAngle = jawAngleOpen;
    }

    public void CloseJaw() {
        jawAngle = jawAngleClosed;
    }



    private void SetSpringParams(float targetAngle,
                                 float damping,
                                 float springCoefficient)
    {
        JointSpring hingeSpring = jointController.spring;
        
        hingeSpring.targetPosition = targetAngle;
        hingeSpring.damper = damping;
        hingeSpring.spring = springCoefficient;

        jointController.spring = hingeSpring;
    }
}
