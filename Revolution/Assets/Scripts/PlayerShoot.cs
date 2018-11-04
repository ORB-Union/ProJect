using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{

    public PlayerWeapon Weapon;

    [SerializeField]
    private Camera cam;
    public ParticleSystem MiddleGunmuzzleFlash;
    public GameObject ImpactEffect;
    public float fireRate = 15.0f;
    public float impactforce = 30.0f;

    public static PlayerShoot Player_Shoot_Singleton;


    //public GameObject Weapon_Reload_SoundObject;
    //public GameObject Weapon_Shoot_SoundObject;

    //public GameObject MiddleGunSound;

    //public GameObject Weapon_Reload_Sound;

    private AudioSource Weapon_Shoot_Sound; // 총발사효과음
    public AudioClip Weapon_Shooting_Sound; // 총발사효과음


    private float totalTimeBeforeDestroy; // 재생효과음 무기변경시 재생되는것을 방지시도


    private AudioSource Weapon_Reload_Sound; // 총 재장전 효과음
    public AudioClip Weapon_Reloading_Sound; // 총 재장전 효과음
    

    private float nextTimeToFire = 0f;

    //총알 장전
    public int Total_Max_Ammo; // 가질수있는 최대 탄창
    public int Max_Ammo = 10; // 최대 탄창
    private int Current_Ammo; // 현재 탄약
    private int Current_Ammo_int; // 현재 탄약 저장변수
    public float Reload_Time = 1f; // 재장전 시간
    private bool Is_Reloading = false;
    private bool is_Shooting = false;

    public Animator Weapon_Animaitor; // 애니메이션 


    public Transform Weapon_Ammo_Text_Current; // 무기 탄창 정보
    public Transform Weapon_Ammo_Text_Total; // 무기 탄창 정보

    private bool Running_Check;

    //public AudioSource GunSound;
    //private AudioClip clip;
    //public GameObject GunPrefab;

    //[SerializeField]
    //private LayerMask mask;

    // Update is called once per frame

    void Awake()
    {
        Player_Shoot_Singleton = this;
    }

    void Start()
    {
        Running_Check = false;
        this.Weapon_Shoot_Sound = this.gameObject.AddComponent<AudioSource>();
        this.Weapon_Reload_Sound = this.gameObject.AddComponent<AudioSource>();


        Current_Ammo = Max_Ammo;
        Weapon_Ammo_Text_Current.GetComponent<Text>().text = Current_Ammo.ToString();
        Weapon_Ammo_Text_Total.GetComponent<Text>().text = Total_Max_Ammo.ToString();
    }


    void FixedUpdate()
    {
        AnimatorStateInfo info = Weapon_Animaitor.GetCurrentAnimatorStateInfo(0);
        if (info.IsName("Raygun_Shoot"))
        {
            Weapon_Animaitor.SetBool("Shooting", false);
        }

        if (info.IsName("Sniper_Shoot"))
        {
            Weapon_Animaitor.SetBool("Shooting", false);
        }
        
        }
    void Update()
    {
        Weapon_Shoot_Sound.volume = 0.5f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Weapon_Animaitor.SetBool("Running", true);
            Running_Check = true;
        }

        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Weapon_Animaitor.SetBool("Running", false);
            Running_Check = false;
        }



        if (Is_Reloading == false)
        {
            Weapon_Reload_Sound.Stop();
        }

        //if (is_Shooting == false)
        //{
        //    Weapon_Shoot_Sound.Stop();
        //}


        if (Is_Reloading)
        {
            return;
        }

        if (Current_Ammo <= 0 || Input.GetButton("Reload_Button") && Current_Ammo < Max_Ammo)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;

            Shoot();
        }

    }

    IEnumerator Reload()
    {
        //_Shooting = false;
        Current_Ammo_int = Max_Ammo - Current_Ammo;
        //Debug.Log("Reloading..");
        Is_Reloading = true;

        this.Weapon_Reload_Sound.Stop();
        Reload_Sound();
        this.Weapon_Shoot_Sound.Stop();

        Weapon_Animaitor.SetBool("Reloading", true);
        yield return new WaitForSeconds(Reload_Time + 0.35f);
        Weapon_Animaitor.SetBool("Reloading", false);
        yield return new WaitForSeconds(-0.25f);

        Current_Ammo = Max_Ammo;

        Weapon_Ammo_Text_Current.GetComponent<Text>().text = Current_Ammo.ToString();


        Total_Max_Ammo = Total_Max_Ammo - Current_Ammo_int;
        Weapon_Ammo_Text_Total.GetComponent<Text>().text = Total_Max_Ammo.ToString();



        Is_Reloading = false;

    }



    void Shoot()
    {
        Weapon_Animaitor.SetBool("Shooting", true);
        this.Weapon_Shoot_Sound.Stop();
        this.Weapon_Reload_Sound.Stop();
        Shoot_Sound();
        //GunSound = GunPrefab.GetComponent<AudioSource>();
        //GunSound.PlayOneShot(clip);
        MiddleGunmuzzleFlash.Play();

        Current_Ammo--;
        Weapon_Ammo_Text_Current.GetComponent<Text>().text = Current_Ammo.ToString();

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
                if (Weapon.WeaponName == "RayGun")
                {
                    Cy_target.TakeDamage(Weapon.damage);
                }

                else if (Weapon.WeaponName == "Long Range Weapon")
                {
                    Cy_target.TakeDamage(Weapon.damage);
                }

            }

            ACS17_Turret_Health Tr_target = _hit.transform.GetComponent<ACS17_Turret_Health>();
            if (Tr_target != null)
            {
                if (Weapon.WeaponName == "RayGun")
                {
                    Tr_target.TakeDamage(Weapon.damage / 2);
                }

                else if (Weapon.WeaponName == "Long Range Weapon")
                {
                    Tr_target.TakeDamage(Weapon.damage);
                }
            }

            Boss_Health Boss_Target = _hit.transform.GetComponent<Boss_Health>();
            if (Boss_Target != null)
            {
                if (Weapon.WeaponName == "RayGun")
                {
                    Boss_Target.Boss_TakeDamage(Weapon.damage);
                }

                else if (Weapon.WeaponName == "Long Range Weapon")
                {
                    Boss_Target.Boss_TakeDamage(Weapon.damage / 2);
                }
            }

            if (_hit.rigidbody != null)
            {
                _hit.rigidbody.AddForce(-_hit.normal * impactforce);
            }

            GameObject impactGo = Instantiate(ImpactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(impactGo, 0.5f);
        }
    }

    public void Reload_Sound()
    {
        this.Weapon_Reload_Sound.clip = this.Weapon_Reloading_Sound;
        this.Weapon_Reload_Sound.loop = false;
            
        this.Weapon_Reload_Sound.Stop();
        this.Weapon_Reload_Sound.Play();
    }

    public void Shoot_Sound()
    {

        this.Weapon_Shoot_Sound.clip = this.Weapon_Shooting_Sound;
        this.Weapon_Shoot_Sound.loop = false;

        this.Weapon_Shoot_Sound.Stop();
        this.Weapon_Shoot_Sound.Play();
    }

    public void Total_Ammo_Increase(int Ammo_Cost)
    {
        Total_Max_Ammo += Ammo_Cost;
    }




    //void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "AmmoBox")
    //    {
    //        if (Input.GetButton("Use"))
    //        {
    //            Total_Ammo_Increase(30);
    //        }
    //    }

    //}



}
