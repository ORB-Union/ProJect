using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Boss_Health : MonoBehaviour
{

    public float Boss_health = 100.0f;
    private float Current_Boss_health;
    private float Second_To_Hide = 2f; // 체력바가 보였다 사라지는 시간
    Boss_AI Boss;


    private AudioSource Boss_Damage_Sound; // 근거리 ai 피격효과음
    public AudioClip Boss_Damaging_Sound; // 근거리 ai 피격 효과음

    private AudioSource Boss_Die_Sound; // ai 사망 효과음
    public AudioClip Boss_Dieing_Sound; // ai 사먕 효과음

    public ParticleSystem Boss_Blood_Splash; // 피격시 피 튀는 효과



    public event Action<float> Boss_OnHealthPctChanged = delegate { };

    public GameObject Turn_On_HealthBar; // 적이 피격시 체력바가 활성화



    private void Start()
    {
        Turn_On_HealthBar.SetActive(false);
        Boss = GetComponent<Boss_AI>();

        this.Boss_Damage_Sound = this.gameObject.AddComponent<AudioSource>();
        this.Boss_Die_Sound = this.gameObject.AddComponent<AudioSource>();

        Current_Boss_health = Boss_health;


    }

    void Update()
    {
        if (Current_Boss_health <= 0)
        {
            Invoke("GameClear", 2.0f);
        }
    }

    public void Boss_TakeDamage(float amount)
    {
        Turn_On_Canvas();
        Boss_Blood_Splash.Play();
        Damage_Sound();
        Current_Boss_health -= amount;

        float Current_Health_Pct = (float)Current_Boss_health / (float)Boss_health;
        Boss_OnHealthPctChanged(Current_Health_Pct);


        if (Current_Boss_health<= 0f)
        {
            Die();
            Current_Boss_health = 0f;
        }
    }

    public void Die()
    {
        Die_Sound();
        Boss.Boss_Death();

        Destroy(gameObject, 4f);
        
    }

    void GameClear()
    {
        SceneManager.LoadScene("Stage_Clear");
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

    void Damage_Sound()
    {
        this.Boss_Damage_Sound.clip = this.Boss_Damaging_Sound;
        this.Boss_Damage_Sound.loop = false;
        this.Boss_Damage_Sound.Play();
    }

    void Die_Sound()
    {
        this.Boss_Die_Sound.clip = this.Boss_Dieing_Sound;
        this.Boss_Die_Sound.loop = false;
        this.Boss_Die_Sound.Play();
    }


    IEnumerator Reset_TurnOn_Canvas()
    {
        yield return new WaitForSeconds(Second_To_Hide);
        Turn_On_HealthBar.SetActive(false);
    }
}
