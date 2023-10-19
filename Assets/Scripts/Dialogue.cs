using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public string text;
    public List<Option> Options;

    public string Text => text;

    public Dialogue(string text, List<Option> options)
    {
        this.text = text;
        Options = options;
    }
}
