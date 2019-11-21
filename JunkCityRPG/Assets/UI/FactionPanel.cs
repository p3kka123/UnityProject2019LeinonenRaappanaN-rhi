using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FactionPanel : MonoBehaviour
{
    private TextMeshProUGUI text;

    private string textString;

    public void PrintFactions()
    {
        if (text == null) text = GetComponentInChildren<TextMeshProUGUI>();
        textString = "";
        foreach(Faction faction in FactionManager.Instance.Factions)
        {
            print(faction.name + " encountered " + faction.FactionEncountered);
            if (faction.FactionEncountered)
                textString += faction.FactionName + "\r\t\t\t\t\t\t\t" + faction.GetFactionOpinion() + "\n";
        }
        text.SetText(textString);
    }
}
