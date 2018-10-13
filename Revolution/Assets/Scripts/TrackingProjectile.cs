using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingProjectile : BaseProjectile
{
    GameObject m_target;
    GameObject m_launcher;
    float m_damage;

    Vector3 m_lastKnownPosition;

    // Update is called once per frame
    void Update()
    {
        if (m_target)
        {
           //transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, speed * Time.deltaTime);
            m_lastKnownPosition = m_target.transform.position;
        }

        else
        {
            if (transform.position == m_lastKnownPosition)
            {
                Destroy(gameObject);
            }
        }
    }


    public override void FireProjectile(GameObject launcher, GameObject target, float damage, float attackspeed)
    {
        if (target)
        {
            m_target = target;
            m_lastKnownPosition = target.transform.position;
            m_launcher = launcher;
            m_damage = damage;
        }
    }


}