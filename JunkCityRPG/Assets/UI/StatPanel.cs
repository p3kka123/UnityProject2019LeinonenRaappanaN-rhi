using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatPanel : MonoBehaviour
{
    private TextMeshProUGUI text;

    public void PrintStats()
    {
        if(text == null)text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText("Name: \t" + PlayerManager.Instance.Stats.Name
            + "\nStrength: \t" + PlayerManager.Instance.Stats.Strength.ToString()
            + "\nLevel: \t" + PlayerManager.Instance.Stats.Level.ToString());
    }

}
