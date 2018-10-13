using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Critiacl_Damage : MonoBehaviour {

    Boss_AI Boss;
    Boss_Health Boss_heal;


    private void Start()
    {
        Boss = GetComponent<Boss_AI>();
        Boss_heal = gameObject.GetComponent<Boss_Health>();
    }



    public void Boss_Critical_Take_Damage(float Critical_Amount)
    {
        Boss_heal.Boss_health -= Critical_Amount;
        if (Boss_heal.Boss_health <= 0)
        {
            Boss_heal.Die();
        }
        
    }
}
