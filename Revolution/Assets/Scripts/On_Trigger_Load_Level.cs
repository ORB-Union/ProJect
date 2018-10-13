using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Trigger_Load_Level : MonoBehaviour {

    public GameObject guiObject;
    public string LevelToLoadScene;


	// Use this for initialization
	void Start () {
        guiObject.SetActive(false);
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButton("Use"))
            {
                Application.LoadLevel(LevelToLoadScene);
            }
        }
    }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
    }
}
