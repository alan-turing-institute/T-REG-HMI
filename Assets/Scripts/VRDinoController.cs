using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class VRDinoController : MonoBehaviour
{
    public GameObject leftControllerGO;
    public GameObject rightControllerGO;
    XRController leftController;
    XRController rightController;
    UnityEngine.XR.InputDevice deviceLeft;
    UnityEngine.XR.InputDevice deviceRight;
    
    bool leftTriggerPressedPreviousFrame = false;
    bool rightTriggerPressedPreviousFrame = false;
    bool leftGripPressedPreviousFrame = false;
    bool rightGripPressedPreviousFrame = false;
    public GameObject testSphere;
    public GameObject testCube;

    public float tailMove=50;

    private MoveLeg leftLegMover;
    private MoveLeg rightLegMover;

    private WagTail tailWagger;
    private JawOpener jawOpener;

    void ToggleTestSphere() {
        if (testSphere.active) testSphere.SetActive(false);
        else testSphere.SetActive(true);
    }

    void ToggleTestCube() {
        if (testCube.active) testCube.SetActive(false);
        else testCube.SetActive(true);
    }

    void Start()
    {
        GameObject leftThigh = GameObject.Find("left_thigh");
        leftLegMover = leftThigh.GetComponent<MoveLeg>();

        GameObject rightThigh = GameObject.Find("right_thigh");
        rightLegMover = rightThigh.GetComponent<MoveLeg>(); 

        tailWagger = GetComponent<WagTail>();
        jawOpener = GetComponent<JawOpener>();

        leftController = leftControllerGO.GetComponent<XRController>();
        rightController = rightControllerGO.GetComponent<XRController>();
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        if(leftHandDevices.Count == 1)
        {
            deviceLeft = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", deviceLeft.name, deviceLeft.role.ToString()));
        }
        var rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);

        if(rightHandDevices.Count == 1)
        {
            deviceRight = rightHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", deviceRight.name, deviceRight.role.ToString()));
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        // Left Trigger / Grip
        if (deviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerButtonPressed) && leftTriggerButtonPressed) {

           // if (! leftTriggerPressedPreviousFrame) {
                
             //   leftTriggerPressedPreviousFrame = true;
            leftLegMover.MoveLegForwards();
             //   ToggleTestSphere();
            //}
        } else if (deviceLeft.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripButtonPressed) && leftGripButtonPressed) {
           // leftTriggerPressedPreviousFrame = false;
            leftLegMover.MoveLegBackwards();
        } else  {   
            leftLegMover.StopLeg();

        }
        // Right Trigger / Grip
        if (deviceRight.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerButtonPressed) && rightTriggerButtonPressed) {

            //if (! rightTriggerPressedPreviousFrame) {
                
              //  rightTriggerPressedPreviousFrame = true;
                rightLegMover.MoveLegForwards();
               // ToggleTestCube();
           // }
        } else if (deviceLeft.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripButtonPressed) && leftGripButtonPressed) { 
            //rightTriggerPressedPreviousFrame = false;
            rightLegMover.MoveLegBackwards();
        } else {
            rightLegMover.StopLeg();
        }

        // right and left primary buttons for the tail
        if (deviceLeft.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftPrimaryButtonPressed) && leftPrimaryButtonPressed) { 
            tailWagger.MoveTail(tailMove);
        } else if (deviceRight.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightPrimaryButtonPressed) && rightPrimaryButtonPressed) { 
            tailWagger.MoveTail(-1*tailMove);
        } else {
            tailWagger.MoveTail(0f);
        }

        // right and left secondary buttons for the tail
        if (deviceLeft.TryGetFeatureValue(CommonUsages.secondaryButton, out bool leftSecondaryButtonPressed) && leftSecondaryButtonPressed) { 
            jawOpener.OpenJaw();
        } else if (deviceRight.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rightSecondaryButtonPressed) && rightSecondaryButtonPressed) { 
            jawOpener.CloseJaw();
        } 

    }
}
