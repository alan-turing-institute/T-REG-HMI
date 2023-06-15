using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using JsonSchema;

public class WebSocketsMove : MonoBehaviour
{
    string command = null;
    string previousCommand = null;
	public string webSocketsIP;
	public string webSocketsPort;
    

    // provide access to javascript method
    [DllImport("__Internal")]
    private static extern void WebSocketInit(string url);
    
    // recieve message called from javascript
    void RecieveMessage(string message) {
	    command = message;
    }

    void Start() {
	WebSocketInit("ws://"+webSocketsIP+":"+webSocketsPort+"/");
    print("Trying to connect to ws://"+webSocketsIP+":"+webSocketsPort+"/");
    
    }
    
    void ToggleTestSphere() {
        GameObject sphere = GameObject.Find("TestSphere");
        if (! sphere.active) sphere.SetActive(true);
        else sphere.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if ((command == "Unity") &&(previousCommand != "Unity")) print("Connected to unity");
        else if ((command == "click") && (previousCommand != "click")) {
            print("click!");
            ToggleTestSphere();
        }  else if ((command == "centred") && (previousCommand != "centred")) print("recentered joystick");
        else if ((command != null) && (command != previousCommand)) {
            print("command is "+command);
            
            try {
                JoystickData joystickData = JsonUtility.FromJson<JoystickData>(command);
			   
		    }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to parse JSON: " + e.Message);
            }
            
        }
        previousCommand = command;
    }
}
