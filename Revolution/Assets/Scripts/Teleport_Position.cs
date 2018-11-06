using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Position : MonoBehaviour {


    public GameObject Target_Position = null;
    public GameObject Boss;

    public float transformTime = 2.0f;
    private Vector3 StartPosition;

    private float movespeed;
    private float rotspeed;


    void Start()
    {
        StartPosition = this.gameObject.transform.position;
        Boss.SetActive(false);
        movespeed = Vector3.Distance(this.transform.position, Target_Position.transform.position) / transformTime;
        rotspeed = Quaternion.Angle(this.transform.rotation, Target_Position.transform.rotation) / transformTime;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.G))
        {
            Boss.SetActive(true);
            transform.position = new Vector3(Target_Position.transform.position.x, Target_Position.transform.position.y, Target_Position.transform.position.z);            
        }

    }
}
