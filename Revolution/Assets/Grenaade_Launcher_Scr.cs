using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenaade_Launcher_Scr : MonoBehaviour {

    [SerializeField]
    public float Launch_Fire_Rate = 10f;
    public float Greade_Launch_Force = 40f;
    public GameObject Grenade_Object;

    public GameObject Launch_Sound;


    private float Launch_Fire_Delay = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame 
	void Update () {

        if(Input.GetButton("Fire1") && Time.time >= Launch_Fire_Delay)
        {
            Launch_Grenade();
            Launch_Fire_Delay = Time.time + 1f / Launch_Fire_Rate;

        }
		
	}

    void Launch_Grenade()
    {
        GameObject Grenade = Instantiate(Grenade_Object, transform.position, transform.rotation) as GameObject;
        Rigidbody rb = Grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Greade_Launch_Force, ForceMode.VelocityChange);
    }
}
