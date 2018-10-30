using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Tuto_Start : MonoBehaviour
{

    public Canvas Back;
    public Canvas Canvas1;
    public Canvas Canvas2;
    public Canvas Canvas3;
    public Canvas Canvas4;

    private GameObject player;

    int count;
    
    // Use this for initialization
    void Start()
    {
        count = 0;
       
        Back.enabled = false;
        Canvas1.enabled = false;
        Canvas2.enabled = false;
        Canvas3.enabled = false;
        Canvas4.enabled = false;

        player = GameObject.Find("Player(FPS) / STAGE 0");


    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "PlayerFPS")
        {
            Time.timeScale = 0;
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
                Time.timeScale = 0;
                Destroy(gameObject);
                

            }
        }
    }

    void OnTriggerExit()
    {
        Back.enabled = false;
        Canvas1.enabled = false;
        Canvas2.enabled = false;
        Canvas3.enabled = false;
        Canvas4.enabled = false;
        Destroy(gameObject);
    }



    // Update is called once per frame
    //void Update()
    //{
    //    if (player.transform.position.x >= -60 && player.transform.position.x <= -48 && player.transform.position.y <= 130 && player.transform.position.y >= 110 && player.transform.position.z >= -40 && player.transform.position.z <= -30)
    //    {
    //        Time.timeScale = 0;
    //        if (Input.GetKeyDown(KeyCode.E))
    //        {
    //            count++;
    //            if (count == 0)
    //            {
    //                Back.enabled = true;
    //                Canvas1.enabled = true;
    //            }
    //            else if (count == 1)
    //            {
    //                Canvas1.enabled = false;
    //                Canvas2.enabled = true;
    //            }
    //            else if (count == 2)
    //            {
    //                Canvas2.enabled = false;
    //                Canvas3.enabled = true;
    //            }
    //            else if (count == 3)
    //            {
    //                Canvas3.enabled = false;
    //                Canvas4.enabled = true;
    //            }
    //            else if (count == 4)
    //            {
    //                Canvas4.enabled = false;
    //                Back.enabled = false;
    //                Time.timeScale = 1;
    //                //Destroy(gameObject);

    //            }
    //        }
    //    }
    //}
}