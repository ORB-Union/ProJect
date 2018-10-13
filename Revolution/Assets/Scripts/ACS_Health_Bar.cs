using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ACS_Health_Bar : MonoBehaviour {

    [SerializeField]
    private Image ACS_Current_Health_Bar;
    [SerializeField]
    private float ACS_updateSpeedSeconds = 0.1f;



    private void Awake()
    {
        GetComponentInParent<ACS17_Turret_Health>().ACS_OnHealthPctChanged += ACS_HandledHealthChanged;
    }


    private void ACS_HandledHealthChanged(float pct) // 체력바 변화
    {
        //Current_Health_Bar.fillAmount = pct;
        StartCoroutine(ACS_ChangeToPerchent(pct));
    }

    private IEnumerator ACS_ChangeToPerchent(float pct) // 체력바 변화
    {
        float preChangePct = ACS_Current_Health_Bar.fillAmount;
        float elapsed = 0f;

        while (elapsed < ACS_updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            ACS_Current_Health_Bar.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / ACS_updateSpeedSeconds);
            yield return null;
        }

        ACS_Current_Health_Bar.fillAmount = pct;
    }

}
