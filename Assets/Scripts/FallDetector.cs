using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetector : MonoBehaviour
{
    public GameObject head;
    public float threshold = 1;

    private Vector3 startPosition;
    private float totalDistance;
    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance( 
            startPosition, transform.position 
            );
        totalDistance += distance;
        startPosition = transform.position;
        print(totalDistance);
        
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
