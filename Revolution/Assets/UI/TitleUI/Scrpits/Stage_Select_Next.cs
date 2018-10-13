using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Select_Next : MonoBehaviour {

	public Canvas Stage_1;
    public Canvas Stage_2;
    public Canvas Stage_3;

    private bool Stage_2_Select;
    private bool Stage_3_Select;
	//public bool Next;
	public GameObject NButton;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Gonext()
	{
        Stage_2_Select = false;
        Stage_3_Select = false;

        
        if(Stage_2_Select == false && Stage_3_Select == false)
        {
            Stage_2_Select = true;
            Stage_3_Select = false;

            Stage_1.enabled = true;
            Stage_2.enabled = false;
            Stage_3.enabled = false;
        }

        if (Stage_2_Select == true && Stage_3_Select == false)
        {
            Stage_2_Select = false;
            Stage_3_Select = true;

            Stage_1.enabled = false;
            Stage_2.enabled = true;
            Stage_3.enabled = false;
            
        }

        if(Stage_2_Select == false && Stage_3_Select == true)
        {
            Stage_2_Select = false;
            Stage_3_Select = false;

            Stage_1.enabled = false;
            Stage_2.enabled = false;
            Stage_3.enabled = true;
        }
	}

}
