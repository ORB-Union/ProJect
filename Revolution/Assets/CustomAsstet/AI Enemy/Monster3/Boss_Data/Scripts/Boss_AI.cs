
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using S3;
using UnityEngine.SceneManagement;

public class Boss_AI : MonoBehaviour{


    [SerializeField]
    private Transform Boss_Player_Target;

    [SerializeField]
    private float Boss_Player_Distance = 2.0f; // 조정가능한 연구원과 플레이어 간의 거리
    private float Boss_Distance; // 미친연구원과 플레이어 사이의 거리

    [SerializeField]
    private float Boss_TurnSpeed = 5.0f; // 연구원이 플레이어를 공격할때 플레이러를 바라보게끔 만드는 요소

    [SerializeField]
    float Boss_AttackTime = 0.1f; // 연구원 공격속도 조정, 애니메이션이랑 최대한 비슷하게끔

    public bool Boss_Can_Attack = true;

    private NavMeshAgent Boss_Agent; // 네비매쉬를 활용
    private Animator Boss_Anim; // 미친연구원의 애니메이션

    private bool Boss_Dead = false; // 미친연구원 죽음여부 확인
    public float Boss_AttackDamage = 3.5f;

	// Use this for initialization
	void Start ()
    {
        Boss_Player_Target = GameObject.FindGameObjectWithTag("PlayerFPS").transform;
        Boss_Agent = GetComponent<NavMeshAgent>();
        Boss_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Boss_Distance = Vector3.Distance(transform.position, Boss_Player_Target.position);


        if (Boss_Distance <= Boss_Player_Distance && !Boss_Dead)
        {
            Boss_Find_Player();

            if (Boss_Distance <= Boss_Agent.stoppingDistance && Boss_Can_Attack)
            {
                // Attack the target
                if (!Boss_Dead)
                {
                    Boss_Attack_Player();
                }
                // Face the target
            }
        }

        else
        {
            Boss_Disable_Enemy();
        }

        //if (Boss_Distance > Boss_Player_Distance && !Boss_Dead)   
        //{
        //    Boss_Find_Player();
        //}

        //else if (Boss_Can_Attack && !Player_Health.Player_Health_Singleton.Player_Dead)
        //{
        //    Boss_Attack_Player();
        //}

        //else if (Player_Health.Player_Health_Singleton.Player_Dead)
        //{
        //    Boss_Disable_Enemy();
        //}


    
	}

    public void Boss_Death()
    {
        Boss_Dead = true;

        //Cyborg_Anim.SetBool("Cyborg_Death", true);
        Boss_Anim.SetTrigger("Boss_Death");

    }

    void Boss_Find_Player() // 연구원이 플레이어를 추적
    {
        Vector3 Boss_Direction = (Boss_Player_Target.position - transform.position).normalized;
        Boss_Direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Boss_Direction), Boss_TurnSpeed * Time.deltaTime);

        Boss_Anim.SetBool("Boss_Idle", false);
        Boss_Agent.updatePosition = true;
        Boss_Agent.updatePosition = true;
        Boss_Agent.SetDestination(Boss_Player_Target.position);
        if (Boss_Can_Attack)
        {
            Boss_Anim.SetBool("Boss_Walking", true);
        }
        Boss_Anim.SetBool("Boss_Attacking", false);

    }

    void Boss_Attack_Player() // 플레이어에게 접근했을경우 공격
    {
        Boss_Agent.updatePosition = false;
        Boss_Agent.updatePosition = false;
        Vector3 Boss_Direction = (Boss_Player_Target.position - transform.position).normalized;
        Boss_Direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Boss_Direction), Boss_TurnSpeed * Time.deltaTime);
        Boss_Anim.SetBool("Boss_Walking", false);
        Boss_Anim.SetBool("Boss_Attacking", true);
        StartCoroutine(Boss_Attack_Delay());
    }

    void Boss_Disable_Enemy()
    {
        //Cyborg_Can_Attack = false;
        Boss_Anim.SetBool("Boss_Idle", true);
        Boss_Anim.SetBool("Boss_Walking", false);
        Boss_Anim.SetBool("Boss_Attacking", false);
    }

    IEnumerator Boss_Attack_Delay() // 연구원 공격 딜레이
    {
        Boss_Can_Attack = false;
        yield return new WaitForSeconds(0.75f);
        Player_Health.Player_Health_Singleton.Damage_Player(Boss_AttackDamage);
        yield return new WaitForSeconds(Boss_AttackTime);
        Boss_Can_Attack = true;
    }
}