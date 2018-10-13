using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACS_Audio_Controller : MonoBehaviour {

    ACS_AI_Controller ACS_Controller;

    //Bullet Fire Sound
    public AudioClip ACS_Fire_Sound;
    //Sound on this object damage
    public AudioClip ACS_Get_Hit_Sound;
    //Turret Reload Sound
    public AudioClip ACS_Reload_Sound;
    //Turret Run out of Bullets Sound
    public AudioClip ACS_Out_Of_Ammo_Sound;

    //Audio Source to Run all above sounds
    AudioSource ACS_AudioSource;

	// Use this for initialization
	void Start () {

        ACS_Controller = this.GetComponent<ACS_AI_Controller>();
        ACS_AudioSource = this.GetComponent<AudioSource>();
	}

    //Play sounds Functions
    public void Play_ACS_Fire()
    {
        ACS_AudioSource.PlayOneShot(ACS_Fire_Sound);
    }

    public void Play_ACS_GetHit()
    {
        ACS_AudioSource.PlayOneShot(ACS_Get_Hit_Sound);
    }

    public void Play_ACS_Reload()
    {
        ACS_AudioSource.PlayOneShot(ACS_Reload_Sound);

    }

    public void Play_ACS_Out_Of_Ammo()
    {
        ACS_AudioSource.PlayOneShot(ACS_Out_Of_Ammo_Sound);
    }
}
