using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public Animator Raygun_Ani;
    public Animator Sniper_Ani;

    public int selectedWeapon;
    public GameObject weapon01; // MiddleGun
    public GameObject weapon02;

    public GameObject weapon_UI_01; // MiddleGun
    public GameObject weapon_UI_02;
    //public GameObject weapon03;


    public float MiddleGun_Cost;
    public float Long_RangeGun_Cost;
    public float Launcher_Cost;


	// Use this for initialization
	void Start () {
        //SelectWeapon();
        weapon01.SetActive(true);
        weapon02.SetActive(false);

        weapon_UI_01.SetActive(true);
        weapon_UI_02.SetActive(false);
        //weapon03.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Player_Mana.Player_Mana_Singleton.Weapon_Change())
        {
            if (Input.GetKeyDown("1"))
            {
                weapon01.SetActive(true);
                Raygun_Ani.SetTrigger("Switching");
                Raygun_Ani.SetBool("Idle", true);
                Player_Mana.Player_Mana_Singleton.ConSume_MP(MiddleGun_Cost);
                weapon02.SetActive(false);

                weapon_UI_01.SetActive(true);
                weapon_UI_02.SetActive(false);
                
               // weapon03.SetActive(false);
            }

            if (Input.GetKeyDown("2"))
            {
                Player_Mana.Player_Mana_Singleton.ConSume_MP(Long_RangeGun_Cost);
                weapon01.SetActive(false);
                weapon02.SetActive(true);

                Sniper_Ani.SetTrigger("Switching");
                Sniper_Ani.SetBool("Idle", true);

                weapon_UI_01.SetActive(false);
                weapon_UI_02.SetActive(true);
                //weapon03.SetActive(false);
            }
            /*
            if (Input.GetKeyDown("3"))
            {
                Player_Mana.Player_Mana_Singleton.ConSume_MP(Launcher_Cost);
                weapon01.SetActive(false);
                weapon02.SetActive(false);
                weapon03.SetActive(true);
            }
             */
        }

        //if(Player_Mana.Player_Mana_Singleton.Weapon_Changable == false)
        //{

        //}
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
