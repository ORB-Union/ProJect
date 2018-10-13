using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_Potion : MonoBehaviour {

    [SerializeField]
    float speed = 200;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, speed * Time.deltaTime, 0);
	}
}
