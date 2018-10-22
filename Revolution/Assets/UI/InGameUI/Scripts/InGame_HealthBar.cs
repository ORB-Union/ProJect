using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_HealthBar : MonoBehaviour {

    [SerializeField]
    private float Hp_FillAmount;

    [SerializeField]
    private Image content;

    [SerializeField]
    private Text ValueText;

	// Update is called once per frame
	void Update () {
        Health_HandleBar();
	}

    public float MaxValue
    {
        get;
        set;
    }

    public float Value
    {
        set
        {
            string[] tmp = ValueText.text.Split(':');
            ValueText.text = tmp[0] + ": " + value;
            Hp_FillAmount = Map(value,0,MaxValue,0,1);
        }

    }
    public void Health_HandleBar()
    {
        if (Hp_FillAmount != content.fillAmount)
        {
            content.fillAmount = Hp_FillAmount;
        }
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //(80 -0) * (1 - 0)  / (100 - 0) + 0
        // 80 * 1 / 100 = 0.8
    }
}
