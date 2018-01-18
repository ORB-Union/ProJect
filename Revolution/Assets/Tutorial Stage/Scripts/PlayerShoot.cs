using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon Weapon;

    [SerializeField]
    private Camera cam;
    public ParticleSystem MiddleGunmuzzleFlash;
    public GameObject ImpactEffect;
    public float fireRate = 15.0f;
    public float impactforce = 30.0f;

    private float nextTimeToFire = 0f;

    //[SerializeField]
    //private LayerMask mask;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
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

            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * impactforce);
            }

            GameObject impactGo = Instantiate(ImpactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(impactGo, 2.0f);
        }
    }
}
