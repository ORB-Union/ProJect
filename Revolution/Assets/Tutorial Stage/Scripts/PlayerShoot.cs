using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon Weapon;

    [SerializeField]
    private Camera cam;
<<<<<<< HEAD
    public ParticleSystem MiddleGunmuzzleFlash;
    public GameObject ImpactEffect;
    public float fireRate = 15.0f;
    public float impactforce = 30.0f;

    private float nextTimeToFire = 0f;

    //[SerializeField]
    //private LayerMask mask;
=======

    [SerializeField]
    private LayerMask mask;
>>>>>>> 918914bad8caa99b8a038e22c0fcf5ff56cfa1cd
	
	// Update is called once per frame
	void Update () {
		
<<<<<<< HEAD
        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
=======
        if(Input.GetButtonDown("Fire1"))
        {
>>>>>>> 918914bad8caa99b8a038e22c0fcf5ff56cfa1cd
            Shoot();
        }
	}

    void Shoot()
<<<<<<< HEAD
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
=======
    { 
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, Weapon.range, mask))
        {
            Debug.Log("We hit" + _hit.collider.name);
>>>>>>> 918914bad8caa99b8a038e22c0fcf5ff56cfa1cd
        }
    }
}
