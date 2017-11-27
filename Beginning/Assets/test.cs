using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    // Use this for initialization
    private GUIStyle guiStyle = new GUIStyle();
    bool canInteract = false;
    float displaytime = 3.0f;
    bool displayMsg = false;
    public GameObject player;
    void Update()
    {
        displaytime -= Time.deltaTime;
        if (displaytime <= 0.0)
            displayMsg = false;
    }
        public void OnTriggerStay()
    {
        if (player.tag == "Player")
        {
            displayMsg = true;
            canInteract = true;
            displaytime = 3.0f;
        }
    }
    void OnGUI()
    {
        if (displayMsg)
        {
            if (canInteract)
            {
                
                guiStyle.fontSize = 30;
                guiStyle.normal.textColor = Color.red;
                GUI.Label(new Rect(500, 100, 300, 20), "The wind will extinguish this searing hue",guiStyle);

            }
        }
    }


}
