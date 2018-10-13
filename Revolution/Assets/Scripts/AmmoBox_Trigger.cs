using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox_Trigger : MonoBehaviour {

    public GameObject Ammo_Trigger_Speech;

    public int Ammo_Increase_Cost = 30;


	// Use this for initialization
	void Start () {
        Ammo_Trigger_Speech.SetActive(false);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            Ammo_Trigger_Speech.SetActive(true);
            if (Ammo_Trigger_Speech.activeInHierarchy == true && Input.GetButton("Use"))
            {
                PlayerShoot.Player_Shoot_Singleton.Total_Ammo_Increase(Ammo_Increase_Cost);
                Destroy(gameObject);
                Ammo_Trigger_Speech.SetActive(false);
            }
        }
    }

    void OnTriggerExit()
    {
        Ammo_Trigger_Speech.SetActive(false);
    }
}
