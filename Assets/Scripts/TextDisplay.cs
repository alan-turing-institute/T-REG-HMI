using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplay : MonoBehaviour
{

    private Text announceDisplayText;
    private Text infoDisplayText;

    public void Announce(string s)
    {
        announceDisplayText.text = s;
    }

    public void Info(string s)
    {
        infoDisplayText.text = s;
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject announceDisplay = GameObject.Find("AnnounceDisplay");
        GameObject infoDisplay = GameObject.Find("InfoDisplay");

        announceDisplayText = announceDisplay.GetComponent<Text>();
        infoDisplayText = infoDisplay.GetComponent<Text>();

        Announce("");
        Info("");
    }
}
