using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_HP_Potion : MonoBehaviour {

    [SerializeField]
    float speed = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
	}
}
