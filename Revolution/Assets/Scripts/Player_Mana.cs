using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Mana : MonoBehaviour {

    public static Player_Mana Player_Mana_Singleton;
    public float Player_MP = 100;
    public float Current_Player_MP;

    public bool Weapon_Changable;

    

    [SerializeField]
    private InGame_Mana_Stats Mana_bar;

    void Awake()
    {
        Player_Mana_Singleton = this;
        Mana_bar.Initialize();
    }

	// Use this for initialization
	void Start () {
        Player_MP = 100;
        Mana_bar.CurrentVal_Mp = Player_MP;
        Weapon_Changable = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mana_bar.CurrentVal_Mp >= 100)
        {
            Mana_bar.CurrentVal_Mp = 100;
        }
        else
        {
            Mana_bar.CurrentVal_Mp += Time.deltaTime;   
        }
        
	}


    public bool Weapon_Change()
    {
        if (Mana_bar.CurrentVal_Mp > 15)
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    public void ConSume_MP(float MP_Cost)
    {
        //if(Mana_bar.CurrentVal_Mp > 0)
        //{
        //    Weapon_Changable = true;
        //}

        if (Weapon_Change())
        {
            Mana_bar.CurrentVal_Mp -= MP_Cost;
            if (Mana_bar.CurrentVal_Mp <= 0)
            {
                Mana_bar.CurrentVal_Mp = 0;
                //Weapon_Changable = false;
            }

            //if (Weapon_Changable == false && Mana_bar.CurrentVal_Mp > 0)
            //{
            //    Weapon_Changable = true;
            //}
        }

        //else if (Weapon_Changable == false)
        //{
        //    if (Mana_bar.CurrentVal_Mp > 0)
        //    {
        //        Weapon_Changable = true;
        //    }
        //}
    }

    public void Mp_Increase(float MP_Cost)
    {
        Mana_bar.CurrentVal_Mp += MP_Cost;

        if (Mana_bar.CurrentVal_Mp >= 100)
        {
            Mana_bar.CurrentVal_Mp = 100;
        }
        
    }

    public void Run_Consume_MP()
    {
        if (Mana_bar.CurrentVal_Mp <= 0)
        {
            Mana_bar.CurrentVal_Mp = 0;
        }

        else
        {
            Mana_bar.CurrentVal_Mp -= Time.deltaTime * 3;
        }
    }


}
