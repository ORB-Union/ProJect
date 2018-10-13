using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Effect_Hurt_Splash : MonoBehaviour {

    Image rend;

    void Start()
    {
        rend = GetComponent<Image>();
        Color c = rend.material.color;
        c.a = 0f;

        rend.material.color = c;
    }

	// Update is called once per frame
	void Update () {

        if (Player_Health.Player_Health_Singleton.Current_Plyer_HP >= 100 && Player_Health.Player_Health_Singleton.Current_Plyer_HP >= 80)
        {
            Color c = rend.material.color;
            c.a = 0f;
            rend.material.color = c;
        }

        if (Player_Health.Player_Health_Singleton.Current_Plyer_HP < 80 && Player_Health.Player_Health_Singleton.Current_Plyer_HP >= 60)
        {
            Color c = rend.material.color;
            c.a = 80f;
            rend.material.color = c;
        }

        if (Player_Health.Player_Health_Singleton.Current_Plyer_HP < 60 && Player_Health.Player_Health_Singleton.Current_Plyer_HP >= 40)
        {
            Color c = rend.material.color;
            c.a = 150f;
            rend.material.color = c;
        }

        if (Player_Health.Player_Health_Singleton.Current_Plyer_HP < 40 && Player_Health.Player_Health_Singleton.Current_Plyer_HP >= 20)
        {
            Color c = rend.material.color;
            c.a = 255f;
            rend.material.color = c;
        }
		
	}
}
