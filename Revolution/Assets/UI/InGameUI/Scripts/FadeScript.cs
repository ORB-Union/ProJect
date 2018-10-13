using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {

    private float Transparence;
    public bool FadeOut;
    public float FadeStep = 0.1f;

	// Use this for initialization
	void Start () {

        Transparence = 1f;
		
	}
	
	// Update is called once per frame
	void Update () {

        Transparence = Mathf.Clamp(Transparence, 0, 1);

        if (FadeOut)
        {
            Transparence += FadeStep;
        }

        else
        {
            Transparence -= FadeStep;
        }

        GetComponent<CanvasGroup>().alpha = Transparence;
	}
}
    