using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS_RayCast_Controller : MonoBehaviour
{

    ACS_AI_Controller ACS_Controller;

    public GameObject m_target;



    // For laser effect
    private LineRenderer RayCastPoint_Line;

    //Point from which raycast should start
    public Transform ACS_StartPoint;

    public Collider Other;

    public string PlayerTag = "PlayerFPS";

    bool shootOk = false;

    // Use this for initialization
    void Start()
    {
        RayCastPoint_Line = ACS_StartPoint.GetComponent<LineRenderer>();
        ACS_Controller = this.GetComponent<ACS_AI_Controller>();

    }

    bool SetTargeting(GameObject target)
    {
        if (target.tag == "PlayerFPS")
        {
            m_target = target;
            return true;
        }

        
        
        return false;
    }

    void FixedUpdate() // void Update보다 우선적으로 호출됨
    {
        
        if (ACS_StartPoint && RayCastPoint_Line && !ACS_Controller.ACS_Health.ACS_Destroyed)
        {
            RaycastHit ACS_Hit;
            //get range from the ShootingSystem script
            float ACS_Range = ACS_Controller.ACS_ShootSystem.ACS_Shoot_Range;
            if (Physics.Raycast(ACS_StartPoint.position, ACS_StartPoint.forward, out ACS_Hit, ACS_Range))
            {    
                ACS_Controller.ACS_ShootSystem.Fire(ACS_Hit.point, ACS_Hit.collider.gameObject);
                //if raycast hit somewhere then stop laser effect at that point
                RayCastPoint_Line.SetPosition(1, new Vector3(0, 0, ACS_Hit.distance));
                //if hit some point then shoot through shootingSystem Fire Function
                
            }

            else
            {
                //if not hit, laser till range 
                RayCastPoint_Line.SetPosition(1, new Vector3(0, 0, ACS_Range));
            }
        }
    }

    public void ACS_Turret_Status(bool val)
    {
        RayCastPoint_Line.enabled = val;
    }
}