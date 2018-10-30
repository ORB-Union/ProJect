using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Title_SoundManager : MonoBehaviour {

    //Reference to the AudioSource component
    public AudioSource UI_Title_Audio;

    // Title Option Sound Slider
    public Slider Sound_Volume; 
    
	// Use this for initialization
	void Start () {

        //Get the AudioSource component in the game object
        UI_Title_Audio = GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
        UI_Title_Audio.volume = Sound_Volume.value;
 
	}


    public void Mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    //Turn Music On / Off
    public void SoundOn_Off()
    {
        if (Player_Health.Player_Health_Singleton.Current_Plyer_HP <= 0)
        {
            UI_Title_Audio.mute = false;
        }

        if (UI_Title_Audio.mute == true)
        {
            UI_Title_Audio.mute = false;
        }

        else
        {
            UI_Title_Audio.mute = true;
        }
    }
}
