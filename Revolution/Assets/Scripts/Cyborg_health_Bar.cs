using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Cyborg_health_Bar : MonoBehaviour {

    [SerializeField]
    private Image Current_Health_Bar;
    [SerializeField]
    private float updateSpeedSeconds = 0.1f;

    private void Awake()
    {
        GetComponentInParent<Cyborg_Health>().OnHealthPctChangde += HandledHealthChanged;
    }


    private void HandledHealthChanged(float pct) // 체력바 변화
    {
        //Current_Health_Bar.fillAmount = pct;
        StartCoroutine(ChangeToPerchent(pct));
    }

    private IEnumerator ChangeToPerchent(float pct) // 체력바 변화
    {
        float preChangePct = Current_Health_Bar.fillAmount;
        float elapsed = 0f;

        while(elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            Current_Health_Bar.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        Current_Health_Bar.fillAmount = pct;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
