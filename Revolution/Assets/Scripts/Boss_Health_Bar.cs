using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Health_Bar : MonoBehaviour {

    [SerializeField]
    private Image Boss_Current_Health_Bar;
    [SerializeField]
    private float Boss_updateSpeedSeconds = 0.1f;



    private void Awake()
    {
        GetComponentInParent<Boss_Health>().Boss_OnHealthPctChanged += Boss_HandledHealthChanged;
    }


    private void Boss_HandledHealthChanged(float pct) // 체력바 변화
    {
        //Current_Health_Bar.fillAmount = pct;
        StartCoroutine(Boss_ChangeToPerchent(pct));
    }

    private IEnumerator Boss_ChangeToPerchent(float pct) // 체력바 변화
    {
        float preChangePct = Boss_Current_Health_Bar.fillAmount;
        float elapsed = 0f;

        while (elapsed < Boss_updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            Boss_Current_Health_Bar.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / Boss_updateSpeedSeconds);
            yield return null;
        }

        Boss_Current_Health_Bar.fillAmount = pct;
    }
}
