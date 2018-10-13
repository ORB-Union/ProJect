using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cyborg_Health : MonoBehaviour
{
    //체력
    public float Cyborg_health = 100.0f;

    private float Cyborg_CurrentHealth;
    public event Action<float> OnHealthPctChangde = delegate { };

    public GameObject Turn_On_HealthBar; // 적이 피격시 체력바가 활성화
    private float Second_To_Hide = 2f; // 체력바가 보였다 사라지는 시간


    Cyborg_AI Cyborg;

    private AudioSource Cyborg_Damage_Sound; // 근거리 ai 피격효과음
    public AudioClip Cyborg_Damaging_Sound; // 근거리 ai 피격 효과음

    private AudioSource Cyborg_Die_Sound; // ai 사망 효과음
    public AudioClip Cyborg_Dieing_Sound; // ai 사먕 효과음

    public ParticleSystem Cyborg_Blood_Splash; // 피격시 피 튀는 효과


    private void Start()
    {
        Turn_On_HealthBar.SetActive(false);
        this.Cyborg_Damage_Sound = this.gameObject.AddComponent<AudioSource>();
        this.Cyborg_Die_Sound = this.gameObject.AddComponent<AudioSource>();

        Cyborg = GetComponent<Cyborg_AI>();

        Cyborg_CurrentHealth = Cyborg_health;
    }


    
    public void TakeDamage(float amount)
    {
        Turn_On_Canvas();
        Cyborg_Blood_Splash.Play();
        this.Cyborg_Damage_Sound.clip = this.Cyborg_Damaging_Sound;
        this.Cyborg_Damage_Sound.loop = false;
        this.Cyborg_Damage_Sound.Play();

        Cyborg_CurrentHealth -= amount;

        float Current_Health_Pct = (float)Cyborg_CurrentHealth / (float)Cyborg_health;
        OnHealthPctChangde(Current_Health_Pct);

        


        if (Cyborg_CurrentHealth <= 0f)
        {
            Die();
            Cyborg_CurrentHealth = 0f;
        }
    }

    void Die()
    {
        Cyborg.Cyborg_Death();
        this.Cyborg_Die_Sound.clip = this.Cyborg_Dieing_Sound;
        this.Cyborg_Die_Sound.loop = false;
        this.Cyborg_Die_Sound.Play();
        Destroy(gameObject, 2);
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
