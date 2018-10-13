using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon;
    public GameObject weapon01; // MiddleGun
    public GameObject weapon02;


	// Use this for initialization
	void Start () {
        //SelectWeapon();
        weapon01.SetActive(true);
        weapon02.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("1"))
        {
            weapon01.SetActive(true);
            weapon02.SetActive(false);
        }

        if (Input.GetKeyDown("2"))
        {
            weapon01.SetActive(false);
            weapon02.SetActive(true);
        }
	}


    //void SelectWeapon()
    //{
    //    int i = 0;
    //    foreach (Transform weapon in transform)
    //    {
    //        if(i == selectedWeapon)
    //        {
    //            weapon.gameObject.SetActive(true);
    //        }

    //        else
    //        {
    //            weapon.gameObject.SetActive(false);
    //        }

    //        i++;
            
    //    }
    //}
}
