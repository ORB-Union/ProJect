using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseProjectile {

    GameObject m_launcher;
    public float beamlength = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (m_launcher)
        {
            GetComponent<LineRenderer>().SetPosition(0, m_launcher.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, m_launcher.transform.position + (m_launcher.transform.forward * beamlength));
        }
    }


    public override void FireProjectile(GameObject launcher, GameObject target, float damage, float attackspeed)
    {
        if (launcher)
        {
            m_launcher = launcher;
        }
    }
}
