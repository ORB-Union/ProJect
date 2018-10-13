using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper_Scope : MonoBehaviour
{
    public Canvas CrossHair_UI;

    public Animator Sniper_Animator;    

    private bool Sniper_Scoped = false;

    public GameObject Scope_OverLay;
    public GameObject Weapon_Camera;

    public Camera MainCamera;


    public float ScopedFOV = 15f;

    private float NormalFOV;




    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Sniper_Scoped = !Sniper_Scoped;
            Sniper_Animator.SetBool("Sniper_Scope", Sniper_Scoped);
            Scope_OverLay.SetActive(Sniper_Scoped);

            if (Sniper_Scoped)
            {
                StartCoroutine(On_Scoped());
            }

            else
            {
                On_UnScoped();
            }
        }
    }

    void On_UnScoped()
    {
        Scope_OverLay.SetActive(false);
        Weapon_Camera.SetActive(true);
        CrossHair_UI.enabled = true;

        MainCamera.fieldOfView = NormalFOV;
    }

    IEnumerator On_Scoped()
    {
        yield return new WaitForSeconds(0.15f);
        Scope_OverLay.SetActive(true);
        Weapon_Camera.SetActive(false);
        CrossHair_UI.enabled = false;

        NormalFOV = MainCamera.fieldOfView;
        MainCamera.fieldOfView = 15f;

    }

}