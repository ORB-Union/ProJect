using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleGun : MonoBehaviour {

    RaycastHit hit;

    [SerializeField]
    Transform shootPoint;

    [SerializeField]
    int currentAmmo;


    //Rate Od Fire
    [SerializeField]
    float RateOffFire;
    float NextFire = 0;

    [SerializeField]
    float weponRange;

    public GameObject MiddleGunSound;


    void Update()
    {
        //Fire1은 Edit->Project Setting 에서 세팅된 값을 사용한 것(수정가능)
        if (Input.GetButton("Fire1") && currentAmmo > 0)
        {
            Shoot();
        }
    }


    //총 쏘기
    void Shoot()
    {
        if (Time.time > NextFire)
        {
            NextFire = Time.time + RateOffFire;

            currentAmmo--;


            if (Physics.Raycast(shootPoint.position, shootPoint.forward, out hit, weponRange))
            {
                if (hit.transform.tag == "Enemy")
                {
                    Debug.Log("Hit Enemy");
                }
                else
                {
                    Debug.Log("Hit Something Else");
                }
            }
        }
    }
}
