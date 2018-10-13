
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using S3;

public class Cyborg_AI : MonoBehaviour{


    [SerializeField]
    private Transform Player_Target;

    [SerializeField]
    private float Player_Distance = 2.0f; // 조정가능한 연구원과 플레이어 간의 거리
    private float Cyborg_Distance; // 미친연구원과 플레이어 사이의 거리

    [SerializeField]
    private float Cyborg_TurnSpeed = 5.0f; // 연구원이 플레이어를 공격할때 플레이러를 바라보게끔 만드는 요소

    [SerializeField]
    float Cyborg_AttackTime = 0f; // 연구원 공격속도 조정, 애니메이션이랑 최대한 비슷하게끔

    public bool Cyborg_Can_Attack = true;

    private NavMeshAgent Cyborg_Agent; // 네비매쉬를 활용
    private Animator Cyborg_Anim; // 미친연구원의 애니메이션

    private bool Cyborg_Dead = false; // 미친연구원 죽음여부 확인
    public float Cyborg_AttackDamage = 3.5f;

	// Use this for initialization
	void Start ()
    {
        Player_Target = GameObject.FindGameObjectWithTag("PlayerFPS").transform;
        Cyborg_Agent = GetComponent<NavMeshAgent>();
        Cyborg_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Cyborg_Distance = Vector3.Distance(transform.position, Player_Target.position);


        if (Cyborg_Distance <= Player_Distance && !Cyborg_Dead)
        {
            Find_Player();

            if (Cyborg_Distance <= Cyborg_Agent.stoppingDistance && Cyborg_Can_Attack)
            {
                // Attack the target
                if (!Cyborg_Dead)
                {
                    Attack_Player();
                }
                // Face the target
            }
        }

        else
        {
            Cyborg_Disable_Enemy();
        }

        //if (Cyborg_Distance > Player_Distance && !Cyborg_Dead)   
        //{
        //    Find_Player();
        //}

        //else if (Cyborg_Can_Attack && !Player_Health.Player_Health_Singleton.Player_Dead)
        //{
        //    Attack_Player();
        //}

        //else if (Player_Health.Player_Health_Singleton.Player_Dead)
        //{
        //    Cyborg_Disable_Enemy();
        //}


    
	}

    public void Cyborg_Death()
    {
        Cyborg_Dead = true;

        //Cyborg_Anim.SetBool("Cyborg_Death", true);
        Cyborg_Anim.SetTrigger("Cyborg_Death");

    }

    void Find_Player() // 연구원이 플레이어를 추적
    {
        Vector3 Cyborg_Direction = (Player_Target.position - transform.position).normalized;
        Cyborg_Direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cyborg_Direction), Cyborg_TurnSpeed * Time.deltaTime);

        Cyborg_Anim.SetBool("Cyborg_Idle", false);
        Cyborg_Agent.updatePosition = true;
        Cyborg_Agent.updatePosition = true;
        Cyborg_Agent.SetDestination(Player_Target.position);
        if (Cyborg_Can_Attack)
        {
            Cyborg_Anim.SetBool("Cyborg_Walking", true);
        }
        Cyborg_Anim.SetBool("Cyborg_Attacking", false);

    }

    void Attack_Player() // 플레이어에게 접근했을경우 공격
    {
        Cyborg_Agent.updatePosition = false;
        Cyborg_Agent.updatePosition = false;
        Vector3 Cyborg_Direction = (Player_Target.position - transform.position).normalized;
        Cyborg_Direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cyborg_Direction), Cyborg_TurnSpeed * Time.deltaTime);
        Cyborg_Anim.SetBool("Cyborg_Walking", false);
        Cyborg_Anim.SetBool("Cyborg_Attacking", true);
        StartCoroutine(Cyborg_Attack_Delay());
    }

    void Cyborg_Disable_Enemy()
    {
        //Cyborg_Can_Attack = false;
        Cyborg_Anim.SetBool("Cyborg_Idle", true);
        Cyborg_Anim.SetBool("Cyborg_Walking", false);
        Cyborg_Anim.SetBool("Cyborg_Attacking", false);
    }

    IEnumerator Cyborg_Attack_Delay() // 연구원 공격 딜레이
    {
        Cyborg_Can_Attack = false;
        yield return new WaitForSeconds(0.4f);
        Player_Health.Player_Health_Singleton.Damage_Player(Cyborg_AttackDamage);
        yield return new WaitForSeconds(Cyborg_AttackTime);
        Cyborg_Can_Attack = true;
    }
}