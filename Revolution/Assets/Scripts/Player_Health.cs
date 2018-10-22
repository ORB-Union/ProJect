using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using EZCameraShake;


public class Player_Health : MonoBehaviour
{
    // 카메리 흔들림 효과 
    public float power = 0.7f;
    public float duration = 1.0f;
    public Transform camera;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

    //

    //public Image Hurt_Image;
    
    public GameObject hurtCanvas;

    public Canvas InGame_Canvas;
    public Canvas InGameOptions_Canvas;
    public Canvas Disable_Canvas;
    public Canvas GGMenu;

    private float secondsTillHide = 2;

    private bool Dead_SwitchOn = false;


    public float maxHealth = 100f;

    private AudioSource audio_Hit; // 피격효과음
    public AudioClip audio_Hiting; // 피격효과음


    private AudioSource GameOver_Sound; // 피격효과음
    public AudioClip Game_Overing; // 피격효과음


    //private Game_Master gameManagerMaster;
    //private PlayerMaster playerMaster;
    //public int playerHealth;
    //public Text healthText;



    //void DeductHealth(int healthChange)
    //{
    //    health_bar.CurrentVal -= healthChange;
    //    playerHealth -= healthChange;
    //    if (playerHealth <= 0)
    //    {
    //        playerHealth = 0;
    //        gameManagerMaster.CallEventGameOver();
    //    }
    //}
    
    public static Player_Health Player_Health_Singleton;
    public float Player_HP = 100; // 플레이어의 체력
    public float Current_Plyer_HP; // 현재 플레이어의 체력

    public float ACS_Missile_Damage = 10f;


    bool Player_hit;


    [SerializeField]
    private InGmae_Health_Stats health_bar;


    public bool Player_Dead; // 플레이어 죽음여부

    void Awake()
    {
        GGMenu.enabled = false;
        Player_Health_Singleton = this;
        health_bar.Initialize();

    }

    // Use this for initialization
    void Start()
    {
        Player_hit = false;
        Player_HP = maxHealth;
        Player_Dead = false;
        health_bar.CurrentVal = Player_HP;

        GGMenu.enabled = false;

        this.audio_Hit = this.gameObject.AddComponent<AudioSource>();
        this.GameOver_Sound = this.gameObject.AddComponent<AudioSource>();


        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (health_bar.CurrentVal <= 0)
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            GGMenu.enabled = true;
            // Cursor visible
            Cursor.visible = true;
        }

        else if (GGMenu.enabled == false && Disable_Canvas.enabled == true)
        {
            Time.timeScale = 1;
        }

        if (shouldShake)
        {
            if (duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }

            else
            {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }


    }

    public void Damage_Player(float Enemy_Damage) // 플레이거가 공격을 입을경우
    {
        Player_hit = true;
        this.audio_Hit.clip = this.audio_Hiting;
        this.audio_Hit.loop = false;
        this.audio_Hit.Play();

        shouldShake = true;

        //StartCoroutine(cameraShake.Shake(0.15f, 0.8f));
        //CameraShaker.Instance.ShakeOnce(4f, 4f,.1f,1f);


        health_bar.CurrentVal -= Enemy_Damage;
        TurnOnHurtEffect();

        if (health_bar.CurrentVal <= 0)
        {
            health_bar.CurrentVal = 0;
            Player_Death();
        }


    }

    public void Endure_Hit()
    {
        Player_hit = false;
    }

    void GameOverOnUI()
    {
        GGMenu.enabled = true;
    }

    void Player_Death() // 플레이어가 죽을 경우
    {
        this.GameOver_Sound.clip = this.Game_Overing;
        this.GameOver_Sound.loop = false;
        this.GameOver_Sound.Play();

        if (health_bar.CurrentVal < 0)
        {
            Player_Dead = true;



            Invoke("GameOverOnUI", 0.5f);
            Debug.Log("Player is Dead");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Death_Flag")
        {
            health_bar.CurrentVal -= 100f;
            Player_Death();
        }

        if (other.gameObject.tag == "ACS_Missile")
        {
            Damage_Player(ACS_Missile_Damage);
            TurnOnHurtEffect();
        }
    }

    void TurnOnHurtEffect()
    {
        if (hurtCanvas != null)
        {
            StopAllCoroutines();
            hurtCanvas.SetActive(true);
            StartCoroutine(ResetHurtCanvas());
        }
    }

    IEnumerator ResetHurtCanvas()
    {
        yield return new WaitForSeconds(secondsTillHide);
        hurtCanvas.SetActive(false);
    }


    public void HP_Increase(float HP_Cost)
    {
        if (Player_Dead == false)
        {
            health_bar.CurrentVal += HP_Cost;
        }

        if (health_bar.CurrentVal >= 100 && Player_Dead == false)
        {
            health_bar.CurrentVal = 100;
        }
    }

}