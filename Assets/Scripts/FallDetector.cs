using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    public GameObject head;
    private Vector3 headPosition;
    private float threshold = 1;

    private GameObject lowerSpine;
    private Vector3 spinePosition;
    private float totalDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        lowerSpine = GameObject.Find("lower_spine");
        spinePosition = lowerSpine.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance( 
            spinePosition, lowerSpine.transform.position 
            );
        totalDistance += distance;
        spinePosition = lowerSpine.transform.position;
        
        float headHeight = head.transform.position.y;
        if (headHeight < threshold)
        {
            print("Fell over");
            print("Final distance: "+totalDistance);
            SceneManager.LoadScene( 
                SceneManager.GetActiveScene().buildIndex 
                );
        }
        
    }
}
