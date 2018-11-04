using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mp_Trigger : MonoBehaviour {

    public GameObject MP_Trigger_Speech;


    public float MP_Increase_Cost = 20f;

	// Use this for initialization
	void Start () {
        MP_Trigger_Speech.SetActive(false);
        
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            MP_Trigger_Speech.SetActive(true);
            if (MP_Trigger_Speech.activeInHierarchy == true && Input.GetButton("Use"))
            {   
                Player_Mana.Player_Mana_Singleton.Mp_Increase(MP_Increase_Cost);
                Destroy(gameObject);
                MP_Trigger_Speech.SetActive(false);
            }
        }
    }



    void OnTriggerExit()
    {
        MP_Trigger_Speech.SetActive(false);
    }
}
