using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InGame_Mana_Stats
{

    [SerializeField]
    private InGame_Mana_Bar Mp_bar;

    [SerializeField]
    private float maxVal_Mp;


    public float MaxVal_Mp
    {
        get
        {
            return maxVal_Mp;
        }

        set
        {
            this.maxVal_Mp = value;
            Mp_bar.MaxValue_Mp = maxVal_Mp;
        }
    }


    [SerializeField]
    private float currentVal_Mp;

    public float CurrentVal_Mp
    {
        get
        {
            return currentVal_Mp;
        }

        set
        {
            this.currentVal_Mp = value;
            Mp_bar.Value_Mp = currentVal_Mp;
        }
    }

    public void Initialize()
    {
        this.MaxVal_Mp = maxVal_Mp;
        this.CurrentVal_Mp = currentVal_Mp;
    }
}
