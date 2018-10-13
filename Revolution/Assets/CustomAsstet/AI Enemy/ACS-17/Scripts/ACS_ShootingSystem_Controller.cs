using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS_ShootingSystem_Controller : MonoBehaviour
{

    ACS_AI_Controller ACS_Controller;

    //Random Variables
    bool reloading = false;
    float time = 0;

    //Target to be attacked by turret
    public Transform Player_Target;

    GameObject Player_TargetObject;


    //Effects
    //Bullet Fire effect
    public ParticleSystem ACS_Fire_Muzzile;
    //Effect initialized at point where bullet hits
    public GameObject ACS_Bullet_Effect;

    //Attack
    //Time after which next shot will be fired
    public float ACS_Fire_Delay = 0.1f;
    //Range of the Turret
    public float ACS_Shoot_Range = 20f;

    //Ammo
    //Current available ammo of the gun
    public int ACS_Ammo;
    //Magzine size of the Gun
    public int ACS_MagazineSize = 50;
    //Totale Ammo available for the Gun
    public int ACS_Total_Ammo = 1000;
    //Time taken to reload the Gun
    public float ACS_Reload_Time = 2f;
    //Damage done by the bullet
    public float ACS_Bullet_Damage = 1f;


    // Use this for initialization
    void Start()
    {
        ACS_Controller = this.GetComponent<ACS_AI_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        //check FireDelay after fire
        if (time <= ACS_Fire_Delay)
        {
            time += Time.deltaTime;
        }
    }

    //without Hit Effect
    public void Fire()
    {
        if (ACS_Ammo > 0 && time > ACS_Fire_Delay)
        {
            ACS_Ammo--;

            ACS_Fire_Muzzile.Stop();
            ACS_Fire_Muzzile.Play();
            time = 0;

            ACS_Controller.ACS_Audio.Play_ACS_Fire();
        }

        else
        {
            ACS_Controller.ACS_Audio.Play_ACS_Out_Of_Ammo();
        }

    }

    //with hit effect
    public void Fire(Vector3 HitPoint, GameObject hitObject)
    {
        if (reloading)
        {
            return;
        }

        if (ACS_Ammo > 0)
        {
            if (time > ACS_Fire_Delay)
            {
                ACS_Ammo--;

                ACS_Fire_Muzzile.Stop();
                ACS_Fire_Muzzile.Play();

                hitObject.SendMessage("ApplyDamage", ACS_Bullet_Damage, SendMessageOptions.DontRequireReceiver);
                Instantiate(ACS_Bullet_Effect, HitPoint, Quaternion.identity);

                time = 0;

                ACS_Controller.ACS_Audio.Play_ACS_Fire();

            }

            else
            {
                ACS_Controller.ACS_Audio.Play_ACS_Out_Of_Ammo();
                ACS_Reload();

            }

        }
    }

    //Reload Turret 
    public void ACS_Reload()
    {
        reloading = true;

        StartCoroutine(ReloadAfterDelay());
    }

    //Reload Turret after the delay
    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(ACS_Reload_Time);

        if (ACS_Total_Ammo - ACS_MagazineSize > 0)
        {
            ACS_Total_Ammo -= ACS_MagazineSize;
            ACS_Ammo = ACS_MagazineSize;
        }

        else
        {
            ACS_Ammo = ACS_Total_Ammo;
            ACS_Total_Ammo = 0;
        }

        reloading = false;
    }
}