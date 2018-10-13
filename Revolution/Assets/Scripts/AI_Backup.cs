
////Cyborg_AI_Backup_1
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class Cyborg_AI : MonoBehaviour
//{


//    [SerializeField]
//    private Transform Player_Target;

//    [SerializeField]
//    private float Player_Distance = 10f; // 조정가능한 연구원과 플레이어 간의 거리
//    private float Cyborg_Distance; // 미친연구원과 플레이어 사이의 거리

//    [SerializeField]
//    private float Cyborg_TurnSpeed = 5.0f; // 연구원이 플레이어를 공격할때 플레이러를 바라보게끔 만드는 요소

//    [SerializeField]
//    float Cyborg_AttackTime = 0f; // 연구원 공격속도 조정, 애니메이션이랑 최대한 비슷하게끔

//    public bool Cyborg_Can_Attack = true;

//    private NavMeshAgent Cyborg_Agent; // 네비매쉬를 활용
//    static private Animator Cyborg_Anim; // 미친연구원의 애니메이션

//    private bool Cyborg_Dead = false; // 미친연구원 죽음여부 확인
//    public float Cyborg_AttackDamage = 3.5f;

//    // Use this for initialization
//    void Start()
//    {
//        Player_Target = GameObject.FindGameObjectWithTag("PlayerFPS").transform;
//        Cyborg_Agent = GetComponent<NavMeshAgent>();
//        Cyborg_Anim = GetComponent<Animator>();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//        Find_Player();

//        /*
//        if (Cyborg_Can_Attack && !Player_Health.Player_Health_Singleton.Player_Dead)
//        {
//            Attack_Player();
//        }

//        else if (Player_Health.Player_Health_Singleton.Player_Dead)
//        {
//            Cyborg_Disable_Enemy();
//        }
//        */
//    }

//    public void Cyborg_Death()
//    {
//        Cyborg_Dead = true;
//        //Cyborg_Anim.SetBool("Cyborg_Death", true);
//        Cyborg_Anim.SetTrigger("Cyborg_Death");
//    }

//    void Find_Player() // 연구원이 플레이어를 추적
//    {

//        Cyborg_Distance = Vector3.Distance(Player_Target.position, transform.position);
//        Cyborg_Agent.updatePosition = true;
//        Cyborg_Agent.updatePosition = true;

//        if (Cyborg_Distance < 10 && !Cyborg_Dead)
//        {

//            Vector3 Cyborg_Direction = Player_Target.position - this.transform.position;
//            Cyborg_Direction.y = 0;
//            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cyborg_Direction), Cyborg_TurnSpeed * Time.deltaTime);

//            Cyborg_Anim.SetBool("Cyborg_Idle", false);
//            if (Cyborg_Direction.magnitude > Player_Distance)
//            {
//                Cyborg_Agent.SetDestination(Player_Target.position);
//                Cyborg_Anim.SetBool("Cyborg_Walking", true);
//                Cyborg_Anim.SetBool("Cyborg_Attacking", false);
//                //this.transform.Translate(0, 0, 0.05f);
//            }

//            else
//            {
//                Attack_Player();
//            }
//        }
//        else
//        {
//            Cyborg_Disable_Enemy();
//        }

//    }

//    void Attack_Player() // 플레이어에게 접근했을경우 공격
//    {
//        Cyborg_Agent.updatePosition = false;
//        Cyborg_Agent.updatePosition = false;
//        Vector3 Cyborg_Direction = Player_Target.position - this.transform.position;
//        Cyborg_Direction.y = 0;
//        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Cyborg_Direction), Cyborg_TurnSpeed * Time.deltaTime);
//        Cyborg_Anim.SetBool("Cyborg_Walking", false);
//        Cyborg_Anim.SetBool("Cyborg_Attacking", true);
//        StartCoroutine(Cyborg_Attack_Delay());
//    }

//    void Cyborg_Disable_Enemy()
//    {
//        Cyborg_Can_Attack = false;
//        Cyborg_Anim.SetBool("Cyborg_Idle", true);
//        Cyborg_Anim.SetBool("Cyborg_Walking", false);
//        Cyborg_Anim.SetBool("Cyborg_Attacking", false);

//    }

//    IEnumerator Cyborg_Attack_Delay() // 연구원 공격 딜레이
//    {
//        Cyborg_Can_Attack = false;
//        yield return new WaitForSeconds(53.0f * Time.deltaTime);
//        Player_Health.Player_Health_Singleton.Damage_Player(Cyborg_AttackDamage);
//        //yield return new WaitForSeconds(Cyborg_AttackTime * Time.deltaTime);
//        Cyborg_Can_Attack = true;
//    }
//}

