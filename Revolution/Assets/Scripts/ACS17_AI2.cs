using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS17_AI2 : MonoBehaviour {

    public enum AiStates { NEAREST, FURTHEST, WEAKEST, STRONGEST };

    public AiStates aiStates = AiStates.NEAREST;

    ACS17_TrackingSystem m_tracker;
    ACS17_Shoot_Sys m_shooter;
    RangeChecker m_range;

	// Use this for initialization
	void Start () {
        m_tracker = GetComponent<ACS17_TrackingSystem>();
        m_shooter = GetComponent<ACS17_Shoot_Sys>();
        m_range = GetComponent<RangeChecker>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_tracker || !m_shooter || !m_range)
        {
            return;
        }

        switch (aiStates)
        {

            case AiStates.NEAREST :
                TargetNearest();
                break;
            case AiStates.FURTHEST :
                TargetFurthest();
                break;
            case AiStates.WEAKEST :
                TargetWeakest();
                break;
            case AiStates.STRONGEST :
                TargetStrongest();
                break;
        }
	}


    void TargetNearest()
    {
        List<GameObject> validTargets = m_range.GetValidTargets();
        GameObject curTarget = null;

        float closesDist = 0.0f;

        for (int i = 0; i < validTargets.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);
            if (!curTarget || dist < closesDist)
            {
                curTarget = validTargets[i];
                closesDist = dist;
            }
        }

        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
    }


    void TargetFurthest()
    {
        List<GameObject> validTargets = m_range.GetValidTargets();
        GameObject curTarget = null;

        float furthesDist = 0.0f;

        for (int i = 0; i < validTargets.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);
            if (!curTarget || dist > furthesDist)
            {
                curTarget = validTargets[i];
                furthesDist = dist;
            }
        }

        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);

    }

    void TargetWeakest()
    {

    }

    void TargetStrongest()
    {

    }
}
