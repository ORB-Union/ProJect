using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Trigger_Speech : MonoBehaviour {

    public GameObject Speech_Object;

    //public string LevelToLoadScene;


    // Use this for initialization
    void Start()
    {
        Speech_Object.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            Speech_Object.SetActive(true);
            if (Input.GetButton("Use"))
            {
                Speech_Object.SetActive(false);
            }
        }

        if (other.gameObject.tag == "PlayerFPS" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerExit()
    {
        Speech_Object.SetActive(false);
        //Destroy(gameObject);
    }
}
