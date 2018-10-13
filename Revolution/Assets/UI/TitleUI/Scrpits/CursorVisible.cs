using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Set Cursor to not be visible
	}
	
	// Update is called once per frame
	void Update () {

        Cursor.lockState = CursorLockMode.None;
        // Cursor visible

        Cursor.visible = true;
	}
}
