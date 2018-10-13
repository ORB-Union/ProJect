using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public Canvas InGame_Canvas;

    public Canvas InGameOptions_Canvas;

    public Canvas Disable_Canvas;

    public Canvas GG_Canvas;

    private bool SwitchOn;
    private bool Death;

    void Start()
    {
        SwitchOn = false;
        Death = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && SwitchOn == false)
        {
            InGameOptions_Canvas.enabled = false;
            SwitchOn = true;
            Time.timeScale = 0;
            // Mouse Lock
            Cursor.lockState = CursorLockMode.None;
            // Cursor visible
            Cursor.visible = true;

            InGame_Canvas.enabled = !InGame_Canvas.enabled;

            if (InGame_Canvas.enabled == true || Time.timeScale == 1)
            {
                Disable_Canvas.enabled = false;

            }

            else
            {
                Disable_Canvas.enabled = true;
                Time.timeScale = 1;
            }
        }


        else if (SwitchOn == true)
        {
            SwitchOn = false;
        }
    }

}