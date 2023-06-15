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
    
    private TextDisplay display;

    public float getTotalDistance()
    {
        return totalDistance;
    }

    // Start is called before the first frame update
    void Start()
    {
        lowerSpine = GameObject.Find("lower_spine");
        spinePosition = lowerSpine.transform.position;

        display = GameObject.Find("Canvas").GetComponent<TextDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance( 
            spinePosition, lowerSpine.transform.position 
            );
        totalDistance += distance;
        spinePosition = lowerSpine.transform.position;
        
        display.Info(string.Format("Distance: {0:N1} m", totalDistance / 5.0));

        float headHeight = head.transform.position.y;
        if (headHeight < threshold)
        {
            display.Announce("Fell over!");
            SceneManager.LoadScene( 
                SceneManager.GetActiveScene().buildIndex 
            );
        }
        
    }
}
