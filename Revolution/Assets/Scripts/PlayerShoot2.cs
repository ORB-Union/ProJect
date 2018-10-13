using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot2 : MonoBehaviour {

    public PlayerWeapon Weapon;

    [SerializeField]
    private Camera cam;
    public ParticleSystem MiddleGunmuzzleFlash;
    public GameObject ImpactEffect;
    public float fireRate = 15.0f;
    public float impactforce = 30.0f;

    public GameObject MiddleGunSound;

    private float nextTimeToFire = 0f;

    //[SerializeField]
    //private LayerMask mask;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            GameObject MiddleGunShoot = Instantiate(MiddleGunSound, this.transform.position, this.transform.rotation) as GameObject;
            MiddleGunShoot.transform.parent = this.transform;

            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    void Shoot()
    {
        
        MiddleGunmuzzleFlash.Play();
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, Weapon.range))
        {
            Debug.Log("We hit" + _hit.collider.name);

            Target target = _hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(Weapon.damage);
            }

            Cyborg_Health Cy_target = _hit.transform.GetComponent<Cyborg_Health>();
            if (Cy_target != null)
            {
                Cy_target.TakeDamage(Weapon.damage);
            }

            ACS17_Turret_Health Tr_target = _hit.transform.GetComponent<ACS17_Turret_Health>();
            if (Tr_target != null)
            {
                Tr_target.TakeDamage(Weapon.damage);
            }

            Boss_Health Boss_Target = _hit.transform.GetComponent<Boss_Health>();
            Boss_Critiacl_Damage Boss_critical = _hit.transform.GetComponent<Boss_Critiacl_Damage>();
            if (Boss_Target != null && Weapon.WeaponName == "RayGun")
            {
                Boss_Target.Boss_TakeDamage(Weapon.damage);
            }

            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * impactforce);
            }

            GameObject impactGo = Instantiate(ImpactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(impactGo, 0.5f);
        }
    }
}
