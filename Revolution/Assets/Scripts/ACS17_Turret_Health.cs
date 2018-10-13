using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class ACS17_Turret_Health : MonoBehaviour {

    ACS_Ani_AI Acs;
    public float Turret_health = 100.0f;
    private float Current_Turret_health;

    public event Action<float> ACS_OnHealthPctChanged = delegate { };

    public GameObject Turn_On_HealthBar; // 적이 피격시 체력바가 활성화
    private float Second_To_Hide = 2f; // 체력바가 보였다 사라지는 시간


    public GameObject Explosion_Effect;

    private AudioSource ACS_Damage_Sound; // ai 피격효과음
    public AudioClip ACS_Damaging_Sound; //  ai 피격 효과음

    private AudioSource ACS_Die_Sound; // ai 사망 효과음
    public AudioClip ACS_Dieing_Sound; // ai 사먕 효과음

    
    private void Start()
    {

        Turn_On_HealthBar.SetActive(false);

        Acs = GetComponent<ACS_Ani_AI>();

        Current_Turret_health = Turret_health;

        this.ACS_Damage_Sound = this.gameObject.AddComponent<AudioSource>();
        this.ACS_Die_Sound = this.gameObject.AddComponent<AudioSource>();

        //this.Cyborg_Damage_Sound = this.gameObject.AddComponent<AudioSource>();

        //this.Cyborg_Die_Sound = this.gameObject.AddComponent<AudioSource>();
    }

    public void TakeDamage(float amount)
    {
        Turn_On_Canvas();
        Current_Turret_health -= amount;

        this.ACS_Damage_Sound.clip = this.ACS_Damaging_Sound;
        this.ACS_Damage_Sound.loop = false;
        this.ACS_Damage_Sound.Play();
        
        float Current_Health_Pct = (float)Current_Turret_health / (float)Turret_health;

        ACS_OnHealthPctChanged(Current_Health_Pct);


        
        if(Current_Turret_health <= 0f)
        {
            Die();
            Current_Turret_health = 0f;
        }
    }


    void Die()
    {
        this.ACS_Die_Sound.clip = this.ACS_Dieing_Sound;
        this.ACS_Die_Sound.loop = false;
        this.ACS_Die_Sound.Play();

        Acs.ACS_Death();
        Instantiate(Explosion_Effect, transform.position, transform.rotation);


        Destroy(gameObject, 1.0f);
    }


    void Turn_On_Canvas()
    {
        if (Turn_On_HealthBar != null)
        {
            StopAllCoroutines();
            Turn_On_HealthBar.SetActive(true);
            StartCoroutine(Reset_TurnOn_Canvas());
        }
    }

    IEnumerator Reset_TurnOn_Canvas()
    {
        yield return new WaitForSeconds(Second_To_Hide);
        Turn_On_HealthBar.SetActive(false);
    }
}
