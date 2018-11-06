using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Trigger_Position : MonoBehaviour {

    public GameObject guiObject;

    public GameObject Player;

    public GameObject Boss;

    public GameObject Target_Position = null;
    private Vector3 StartPosition;

    // Use this for initialization
    void Start()
    {
        Boss.SetActive(false);
        StartPosition = this.gameObject.transform.position;
        guiObject.SetActive(false);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            guiObject.SetActive(true);
            if (guiObject.activeInHierarchy == true && Input.GetButton("Use"))
            {
                Boss.SetActive(true);
                Player.transform.position = new Vector3(Target_Position.transform.position.x, Target_Position.transform.position.y, Target_Position.transform.position.z);
            }
        }
    }

    void OnTriggerExit()
    {
        guiObject.SetActive(false);
        //Destroy(gameObject, 1f);
    }
}
