using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour
{
    public GameObject head;
    public float threshold = 1;
    // Start is called before the first frame update
    private Vector3 startposition;
    void Start()
    {
        startposition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float headheight = head.transform.position.y;
        if (headheight < threshold)
        {
            print("fell over");
        }
    }
}
