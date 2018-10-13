using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Trigger_DestroyObject : MonoBehaviour
{

    public GameObject Speech_Object;
    public GameObject Destroy_Object;
    //public string LevelToLoadScene;


    // Use this for initialization
    void Start()
    {
        Speech_Object.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            Destroy(Destroy_Object);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            Speech_Object.SetActive(true);
            //if (Speech_Object.activeInHierarchy == true && Input.GetButton("Use"))
            //{
            //    //Application.LoadLevel(LevelToLoadScene);
            //}
        }
    }

    void OnTriggerExit()
    {
        Speech_Object.SetActive(false);
    }
}
