using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select_menu : MonoBehaviour {

	public Canvas backgroundCanvas;
    public Canvas TutorialstageCanvas;
	public Canvas stage01Canvas;
	public Canvas stage02Canvas;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void select_start(){

		backgroundCanvas.enabled = true;
		TutorialstageCanvas.enabled = true;
	}

	public void menu_disabled(){

		backgroundCanvas.enabled = false;
        TutorialstageCanvas.enabled = false;
		stage01Canvas.enabled = false;
		stage02Canvas.enabled = false;
	}
}
