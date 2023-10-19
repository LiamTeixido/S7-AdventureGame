using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Option : MonoBehaviour
{
    public string text;
    public int requiredStrength;
    public int requiredDexterity;
    public int healthImpact;

    public Action OnSuccessCallback;
    public Action OnFailureCallback;

    public string Text => text;

    public Option(string text, int requiredStrength, int requiredDexterity, int healthImpact, Action OnSuccessCallback, Action OnFailureCallback)
    {
        this.text = text;
        this.requiredStrength = requiredStrength;
        this.requiredDexterity = requiredDexterity;
        this.healthImpact = healthImpact;
        this.OnSuccessCallback = OnSuccessCallback;
        this.OnFailureCallback = OnFailureCallback;
    }
    public abstract void OnSelect();
}
