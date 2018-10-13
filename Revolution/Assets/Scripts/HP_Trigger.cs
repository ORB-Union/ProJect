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
                Destroy(gameObject);
                HP_Trigger_Speech.SetActive(false);
            }

        }
    }

    void OnTriggerExit()
    {
        HP_Trigger_Speech.SetActive(false);
    }
}
