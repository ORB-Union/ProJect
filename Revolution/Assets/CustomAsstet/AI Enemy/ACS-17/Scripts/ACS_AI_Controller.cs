using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS_AI_Controller : MonoBehaviour {


    //All the Scripts reference on this object
    public ACS_Rotation_Controller ACS_Rotation;
    public ACS_RayCast_Controller ACS_RayCast;
    public ACS_ShootingSystem_Controller ACS_ShootSystem;
    public Turret_Health ACS_Health;
    public ACS_Audio_Controller ACS_Audio;


    //Rigidbody Components of the turret
    public Rigidbody[] ACS_Rigidbodies;

    //Mesh Colliders of the turret
    public MeshCollider[] ACS_MeshColliders;

    void Awake()
    {
        //getting all the components on the object. Setting them before RUN state will be a better approach
        ACS_Rotation = this.GetComponent<ACS_Rotation_Controller>();
        ACS_RayCast = this.GetComponent<ACS_RayCast_Controller>();
        ACS_ShootSystem = this.GetComponent<ACS_ShootingSystem_Controller>();
        ACS_Health = this.GetComponent<Turret_Health>();
        ACS_Audio = this.GetComponent<ACS_Audio_Controller>();

    }


    //to enable/disable Rigidbody isKinematic
    // Rigidbody 사용여부
    public void isKinematicRigidbodies(bool val)
    {
        for (int i = 0; i < ACS_Rigidbodies.Length; i++)
        {
            ACS_Rigidbodies[i].isKinematic = val;
        }
    }


    //to enable/disable Mesh Colliders
    // Mesh Collider 사용여부
    public void MeshCollider_Status(bool val)
    {
        for (int i = 0; i < ACS_MeshColliders.Length; i++)
        {
            ACS_MeshColliders[i].enabled = val;
        }

    }
}
