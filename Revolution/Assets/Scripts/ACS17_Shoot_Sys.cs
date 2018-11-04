using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS17_Shoot_Sys : MonoBehaviour {


    public float fireRate;
    public float fieldOfView;
    public float damage;
    public bool beam;
    public GameObject projectile;
    public GameObject target;

    private AudioSource ACS_Shoot_Sound; // 총발사효과음
    public AudioClip ACS_Shooting_Sound; // 총발사효과음

    
    public List<GameObject> projectileSpawns;

    List<GameObject> m_lastProjectiles = new List<GameObject>();

    float m_fireTimer = 0.0f;

    GameObject m_target;

	// Use this for initialization
	void Start () {
        this.ACS_Shoot_Sound = this.gameObject.AddComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!m_target)
        {
            return;
        }
        if (beam && m_lastProjectiles.Count <= 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
            if (angle < fieldOfView)
            {
                SpawnProjectiles();
            }
        }

        else if (beam && m_lastProjectiles.Count > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));
            if (angle > fieldOfView)
            {
                while (m_lastProjectiles.Count > 0)
                {
                    Destroy(m_lastProjectiles[0]);
                    m_lastProjectiles.RemoveAt(0);
                }
            }
        }

        else
        {
            m_fireTimer += Time.deltaTime;

            if (m_fireTimer >= fireRate)
            {
                float angle = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();
                    m_fireTimer = 0.0f;
                }
            }
        }
	}

    void SpawnProjectiles()
    {
        Shoot_Sound();
        if (!projectile)
        {
            return;
        }

        m_lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;
                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], m_target, damage, fireRate);

                m_lastProjectiles.Add(proj);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        m_target = target;
    }


    public void Shoot_Sound()
    {

        this.ACS_Shoot_Sound.clip = this.ACS_Shooting_Sound;
        this.ACS_Shoot_Sound.loop = false;

        this.ACS_Shoot_Sound.Stop();
        this.ACS_Shoot_Sound.Play();
    }


}