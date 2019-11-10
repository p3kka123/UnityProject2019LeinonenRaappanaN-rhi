﻿using System.Collections;
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
            if (faction.FactionEncountered)
                textString += faction.FactionName + "\t" + faction.GetFactionOpinion() + "\n";
        }
        text.SetText(textString);
    }
}
