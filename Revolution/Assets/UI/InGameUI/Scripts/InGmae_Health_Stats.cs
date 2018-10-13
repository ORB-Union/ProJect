using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class InGmae_Health_Stats
{
    [SerializeField]
    private InGame_HealthBar bar;

    [SerializeField]
    private float maxVal;

    
    public float MaxVal
    {
        get
        {
            return maxVal;
        }

        set
        {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    //변화되는 값 체력변화, 데미지를 입을경우 감소
    [SerializeField]
    private float currentVal;
    
    public float CurrentVal
    {
        get
        {
            return currentVal;
        }

        set
        {
            this.currentVal = value;
            bar.Value = currentVal;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }

}