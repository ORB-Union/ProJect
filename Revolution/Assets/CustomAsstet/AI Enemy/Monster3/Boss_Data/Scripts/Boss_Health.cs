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

    public event Action<float> Boss_OnHealthPctChanged = delegate { };

    public GameObject Turn_On_HealthBar; // 적이 피격시 체력바가 활성화



    private void Start()
    {
        Turn_On_HealthBar.SetActive(false);
        Boss = GetComponent<Boss_AI>();

        Current_Boss_health = Boss_health;


    }

    void Update()
    {
        if (Current_Boss_health <= 0)
        {
            Invoke("GameClear", 1.0f);
        }
    }

    public void Boss_TakeDamage(float amount)
    {
        Turn_On_Canvas();
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

    IEnumerator Reset_TurnOn_Canvas()
    {
        yield return new WaitForSeconds(Second_To_Hide);
        Turn_On_HealthBar.SetActive(false);
    }
}
