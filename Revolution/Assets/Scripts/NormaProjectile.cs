using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormaProjectile : BaseProjectile {


    Vector3 m_direction; 
    bool m_fired;
    GameObject m_launcher;
    GameObject m_target;
    float m_damage;
    

	// Update is called once per frame
    void Update()
    {
        if (m_fired)
        {
            transform.position += m_direction * (speed * Time.deltaTime);
        }
    }


    public override void FireProjectile(GameObject launcher, GameObject target, float damage, float attackspeed)
    {
        if (launcher && target)
        {
            m_direction = (target.transform.position - launcher.transform.position).normalized;
            m_fired = true;
            m_launcher = launcher;
            m_target = target;
            m_damage = damage;

            Destroy(gameObject, 5.0f);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerFPS" || other.tag ==  null || other.tag == "Stage")
        {
            Destroy(gameObject, 0);
        }

    }


    //void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject == m_target)
    //    {
    //        DamageData dmgData = new DamageData();
    //        dmgData.damage = m_damage;

    //        Player_Health.Player_Health_Singleton.Damage_Player(m_damage);
    //        Destroy(gameObject);

    //        MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();
    //        if (msgHandler)
    //        {
    //            msgHandler.GiveMessage(MessageTypes.DAMAGED, m_launcher, dmgData);
    //        }

    //    }

    //    if (other.gameObject.GetComponent<BaseProjectile>() == null)
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}