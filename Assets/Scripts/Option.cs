using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public string text;
    public int requiredStrength;
    public int requiredDexterity;
    public int healthImpact { get; set; }
    public Action OnSelect;

    public string Text => text;

    public int HealthImpact { get; internal set; }

    public Option(string text, int requiredStrength, int requiredDexterity, int healthImpact, Action onSelect)
    {
        this.text = text;
        this.requiredStrength = requiredStrength;
        this.requiredDexterity = requiredDexterity;
        this.healthImpact = healthImpact;
        OnSelect = onSelect;
    }
}
