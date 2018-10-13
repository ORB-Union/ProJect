using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Creator : MonoBehaviour {


    public Canvas CreatorCanvas;

    public void select_start()
    {

        CreatorCanvas.enabled = true;
    }

    public void menu_disabled()
    {

        CreatorCanvas.enabled = false;
    }
}
