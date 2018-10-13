using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_UI_Switching : MonoBehaviour {

    public int selectedWeapon;
    public GameObject weapon_UI_01; // MiddleGun
    public GameObject weapon_UI_02;
    //public GameObject weapon_UI_03;

	// Use this for initialization
	void Start () {

        weapon_UI_01.SetActive(true);
        weapon_UI_02.SetActive(false);
        //weapon_UI_03.SetActive(false);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player_Mana.Player_Mana_Singleton.Weapon_Change())
        {
            if (Input.GetKeyDown("1"))
            {
                weapon_UI_01.SetActive(true);
                weapon_UI_02.SetActive(false);
                //weapon_UI_03.SetActive(false);
            }

            if (Input.GetKeyDown("2"))
            {
                weapon_UI_01.SetActive(false);
                weapon_UI_02.SetActive(true);
                //weapon_UI_03.SetActive(false);
            }
            
            //if (Input.GetKeyDown("3"))
            //{

            //    weapon_UI_01.SetActive(false);
            //    weapon_UI_02.SetActive(false);
            //    //weapon_UI_03.SetActive(true);
            //}
            
        }
	}
}
