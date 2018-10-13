using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Health : MonoBehaviour
{

    public float Boss_health = 100.0f;
    Boss_AI Boss;



    private void Start()
    {
        Boss = GetComponent<Boss_AI>();
    }

    void Update()
    {
        if (Boss_health <= 0)
        {
            Invoke("GameClear", 1.0f);
        }
    }

    public void Boss_TakeDamage(float amount)
    {
        Boss_health -= amount;
        if (Boss_health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Boss.Boss_Death();
        Destroy(gameObject, 4);
        
    }

    void GameClear()
    {
        SceneManager.LoadScene("Stage_Clear");
    }
}
