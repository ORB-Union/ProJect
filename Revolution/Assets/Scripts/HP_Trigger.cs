using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Trigger : MonoBehaviour {

    public GameObject HP_Trigger_Speech;  
    public float HP_Increase_Cost = 20f;


	// Use this for initialization
	void Start () {
        HP_Trigger_Speech.SetActive(false);

	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            HP_Trigger_Speech.SetActive(true);
            if (HP_Trigger_Speech.activeInHierarchy == true && Input.GetButton("Use"))
            {
                
                Player_Health.Player_Health_Singleton.HP_Increase(HP_Increase_Cost);
                HP_Trigger_Speech.SetActive(false);
                //Drink_Sound();
                Destroy(gameObject);
            }

        }
    }

    void OnDestroy()
    {
        //Drink_Sound();
    }



    void OnTriggerExit()
    {
        HP_Trigger_Speech.SetActive(false);
    }
}
