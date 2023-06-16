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
    
    private float distanceScale = 1.0f;

    private static float bestDistance;

    private TextDisplay display;

    private bool restartFlag = false;

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
        totalDistance += distanceScale * distance;
        spinePosition = lowerSpine.transform.position;
        
        display.Info(string.Format("Distance: {0:N1} m", totalDistance / 5.0));

        float headHeight = head.transform.position.y;
        if (headHeight < threshold)
        {
            
            if (totalDistance > bestDistance) {
                bestDistance = totalDistance;
            }
            
            display.Announce(
                string.Format(
                    "Fell over!\nPress any key to try again\nBest so far: {0:N1} m",
                    bestDistance / 5.0
                )
            );
            
            distanceScale = 0.0f;
            Time.timeScale = 0.2f;

            Invoke("RestartScene", 0.1f);
        }

        if (Input.anyKey && restartFlag) {
            restartFlag = false;
            Time.timeScale = 1.0f;
            distanceScale = 1.0f;

            SceneManager.LoadScene( 
               SceneManager.GetActiveScene().buildIndex 
            );
        }
    }

    public void RestartScene()
    {
        restartFlag = true;
    }
}
