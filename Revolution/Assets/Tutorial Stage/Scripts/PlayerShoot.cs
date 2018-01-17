using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon Weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    { 
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, Weapon.range, mask))
        {
            Debug.Log("We hit" + _hit.collider.name);
        }
    }
}
