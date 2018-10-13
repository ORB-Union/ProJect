using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ACS_Ani_AI : MonoBehaviour {

    private Animator ACS_Anim; // 미친연구원의 애니메이션
    private bool ACS_Dead = false; // 미친연구원 죽음여부 확인

	// Use this for initialization
	void Start () {

        ACS_Anim = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
        ACS17_Disable_Enemy_Ani();
        
	}


    public void ACS_Death()
    {
        ACS_Dead = true;
        ACS_Anim.SetBool("ACS_Dead2", true);
        //ACS_Anim.SetTrigger("ACS_Dead2");
    }


    void ACS17_Disable_Enemy_Ani()
    {
        ACS_Anim.SetBool("ACS_Idle", true);
        ACS_Anim.SetBool("ACS_Walk", false);
        ACS_Anim.SetBool("ACS_Attack", false);
    }
}
