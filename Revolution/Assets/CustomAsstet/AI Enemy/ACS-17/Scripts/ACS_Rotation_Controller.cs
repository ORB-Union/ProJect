using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS_Rotation_Controller : MonoBehaviour {

    ACS_AI_Controller ACS_Controller;


    //If enabled then gun will aim automatically
    public bool ACS_AutoRotate = true;

    //Gameobject which should rotate to aim the target
    public Transform GunAimPoint;

    //Rotation speed of the Turret
    public float RotationSpeed = 1;




	// Use this for initialization
	void Start () {

        ACS_Controller = this.GetComponent<ACS_AI_Controller>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (ACS_AutoRotate && ACS_CanTarget())
        {
            //Rotate toward the Target with rotation speed
            Quaternion ACS_TargetRotation = Quaternion.LookRotation(ACS_Controller.ACS_ShootSystem.Player_Target.position - GunAimPoint.transform.position, GunAimPoint.transform.up);
            GunAimPoint.transform.rotation = Quaternion.Lerp(GunAimPoint.transform.rotation, ACS_TargetRotation, RotationSpeed * Time.deltaTime);
        }

	}


    //Either Target is in Range or not -> if in range then Rotate and target else donot Rotate
    bool ACS_CanTarget()
    {
        if(ACS_Controller.ACS_Health.ACS_Destroyed)
        {
            return false;
        }

        if (ACS_Controller.ACS_ShootSystem.Player_Target)
        {
            if (Vector3.Distance(this.transform.position, ACS_Controller.ACS_ShootSystem.Player_Target.position) < ACS_Controller.ACS_ShootSystem.ACS_Shoot_Range)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        return false;
    }
}
