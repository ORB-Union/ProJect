using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float PlayerMovespeed = 2.0f;
    public float Sensitivity = 2.0f;

    public GameObject PlayerEyes;
    CharacterController player;

    //move From and Back
    float moveFB;
    //move Left and Right
    float moveLR;

    //Mouse Move
    float rotX;
    float rotY;

	// Use this for initialization
	void Start () {

        player = this.GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
        moveFB = Input.GetAxis("Vertical") * PlayerMovespeed;
        moveLR = Input.GetAxis("Horizontal") * PlayerMovespeed;

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        transform.Rotate(0,rotX,0);
        PlayerEyes.transform.Rotate(-rotY, 0, 0);
        movement = transform.rotation * movement;
        player.Move(movement * Time.deltaTime);

        rotX = Input.GetAxis("Mouse X") * Sensitivity;
        rotY = Input.GetAxis("Mouse Y") * Sensitivity;




	}
}