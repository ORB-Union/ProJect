using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeGameScene_Tutorial_Stage()
	{
        SceneManager.LoadScene("Tutorial_Stage");

	}

    public void ChangeGameScene_Tuto_Cinematic()
    {
        SceneManager.LoadScene("Tuto_Cinematic");
    }

    public void ChangeScene_Tuto_Testing_Stage1()
    {
        SceneManager.LoadScene("Tutorial_Stage_1");
    }

    public void ChangeGameScene_stage01()
    {
        SceneManager.LoadScene("Stage01");

    }


    public void ChangeGameScene_stage02()
    {
        SceneManager.LoadScene("Stage02");

    }

    public void ChangeGameScene_seclect()
    {
        SceneManager.LoadScene ("select");

    }

	public void ChangeGameScene_title()
	{
        SceneManager.LoadScene("Title");

	}

	public void Endgame()
	{
		Application.Quit ();

	}



}
