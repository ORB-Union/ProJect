using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame_Mana_Bar : MonoBehaviour {

    [SerializeField]
    private float Mp_FillAmount;

    [SerializeField]
    private Image content_Mp;

    [SerializeField]
    private Text ValueText_Mp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Mana_HandleBar();
        
	}

    public float MaxValue_Mp
    {
        get;
        set;
    }

    public float Value_Mp
    {
        set
        {
            string[] tmp_Mp = ValueText_Mp.text.Split(':');
            ValueText_Mp.text = tmp_Mp[0] + ": " + value.ToString("0") + ' ' + '%';
            Mp_FillAmount = Map_Mp(value, 0, MaxValue_Mp, 0, 1);
        }
    }

    public void Mana_HandleBar()
    {
        if (Mp_FillAmount != content_Mp.fillAmount)
        {
            content_Mp.fillAmount = Mp_FillAmount;
        }

    }

    private float Map_Mp(float value_Mp , float InMin_Mp, float InMax_Mp, float outMin_Mp, float outMax_Mp)
    {
        return (value_Mp - InMin_Mp) * (outMax_Mp - outMin_Mp) / (InMax_Mp - InMin_Mp) + outMin_Mp;
    }
}
