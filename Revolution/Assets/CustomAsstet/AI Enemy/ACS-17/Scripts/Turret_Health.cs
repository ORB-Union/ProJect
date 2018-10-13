using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Health : MonoBehaviour{

    ACS_AI_Controller ACS_Controller;

    public float Turret_health = 100.0f; // 터렛 체력

    public bool ACS_Destroyed = false; // 터렛 파괴여부

    void Start()
    {
        ACS_Controller = this.GetComponent<ACS_AI_Controller>();
    }


    //Apply damage to Turret
    public void TakeDamage(float amount)
    {
        Turret_health -= amount;

        if (Turret_health <= 0f)
        {
            ACS_Destroyed = true;
            Turret_health = 0;
            Die();
        }

        ACS_Controller.ACS_Audio.Play_ACS_GetHit();


    }

    void Die()
    {
        ACS_Controller.MeshCollider_Status(true);
        ACS_Controller.isKinematicRigidbodies(true);
        ACS_Controller.ACS_RayCast.ACS_Turret_Status(false);
        Destroy(this.gameObject, 2);
    }
}


