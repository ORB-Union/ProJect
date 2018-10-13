using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Cursor_Visility : MonoBehaviour {

    public Canvas Options_UI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Options_UI.enabled == true)
        {
            Cursor.lockState = CursorLockMode.None;
            // Cursor visible

            Cursor.visible = true;
        }
		
	}
}
