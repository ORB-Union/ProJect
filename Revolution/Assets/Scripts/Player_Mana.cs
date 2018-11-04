using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Mana : MonoBehaviour {

    public static Player_Mana Player_Mana_Singleton;
    public float Player_MP = 100;
    public float Current_Player_MP;

    public bool Weapon_Changable;

    private AudioSource MP_Drink_Sound; // 체력회복 효과음
    public AudioClip MP_Drinking_Sound; // 총발사효과음

    

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
        this.MP_Drink_Sound = this.gameObject.AddComponent<AudioSource>();
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
        Drink_Sound();
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

    public void Drink_Sound()
    {
        this.MP_Drink_Sound.clip = this.MP_Drinking_Sound;
        this.MP_Drink_Sound.loop = false;

        this.MP_Drink_Sound.Stop();
        this.MP_Drink_Sound.Play();
    }



}
