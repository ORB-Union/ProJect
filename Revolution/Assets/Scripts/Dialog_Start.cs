using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Start : MonoBehaviour {

    public Canvas Back;
    public Canvas Canvas1;
    public Canvas Canvas2;
    public Canvas Canvas3;
    public Canvas Canvas4;

    public GameObject player;
    int count = 0;

	// Use this for initialization
	void Start () {

        //Back.enabled = false;
        //Canvas1.enabled = false;
        //Canvas2.enabled = false;
        //Canvas3.enabled = false;
        //Canvas4.enabled = false;

        Back.enabled = false;
        Canvas1.enabled = false;
        Canvas2.enabled = false;
        Canvas3.enabled = false;
        Canvas4.enabled = false;
        //Time_River = true;

        player = GameObject.Find("Player(FPS) _ STAGE 2");


	}

    void OnTriggerStay(Collider other)
    {
        //if (other.gameObject.tag == "PlayerFPS")
        //{
        //    {
        //        //Time.timeScale = 0;
        //        Time_River = false;
        //        if (Input.GetKeyDown(KeyCode.E))
        //            count++;
        //        if (count == 0)
        //        {
        //            Back.SetActive(true);
        //            Canvas1.SetActive(true);

        //        }
        //        else if (count == 1)
        //        {
        //            Canvas1.SetActive(false);
        //            Canvas2.SetActive(true);
        //        }
        //        else if (count == 2)
        //        {
        //            Canvas2.SetActive(false);
        //            Canvas3.SetActive(true);
        //        }
        //        else if (count == 3)
        //        {
        //            Canvas3.SetActive(false);
        //            Canvas4.SetActive(true);
        //        }
        //        else if (count == 4)
        //        {
        //            Canvas4.SetActive(false);
        //            Back.SetActive(false);
        //            Destroy(gameObject);
        //            //Time.timeScale = 1;
        //            Time_River = true;
        //        }
        //    }
        //}
    }
	
	// Update is called once per frame
    void Update()
    {
        if (player.transform.position.x >= -64 && player.transform.position.z >= -36
            && player.transform.position.x <= -30 && player.transform.position.z <= -33)
        {
            Time.timeScale = 0;
            //Time_River = false;
            if (Input.GetKeyDown(KeyCode.E))
                count++;
            if (count == 0)
            {
                Back.enabled = true;
                Canvas1.enabled = true;
            }
            else if (count == 1)
            {
                Canvas1.enabled = false;
                Canvas2.enabled = true;
            }
            else if (count == 2)
            {
                Canvas2.enabled = false;
                Canvas3.enabled = true;
            }
            else if (count == 3)
            {
                Canvas3.enabled = false;
                Canvas4.enabled = true;
            }
            else if (count == 4)
            {
                Canvas4.enabled = false;
                Back.enabled = false;
                Destroy(gameObject);
                Time.timeScale = 1;
            }
                //Time_River = true;
        }
    }

}
