using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPotion : MonoBehaviour {

    public float DestroyTime = 3000.0f;

	// Use this for initialization
	void Start () {

        Destroy(gameObject, DestroyTime);
		
	}

}
