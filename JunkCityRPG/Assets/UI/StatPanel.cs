using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatPanel : MonoBehaviour
{
    private TextMeshProUGUI text;
    private StatUpHandler statUpHandler;

    public void PrintStats()
    {
        if (statUpHandler == null) statUpHandler = GetComponentInChildren<StatUpHandler>();
        if(text == null)text = GetComponentInChildren<TextMeshProUGUI>();
        text.SetText("Name: \r\t\t\t" + PlayerManager.Instance.Stats.Name
            + "\n\nLevel: \r\t\t\t" + PlayerManager.Instance.Stats.Level.ToString()
            + "\n\nExperience: \r\t\t\t" + PlayerManager.Instance.Stats.Exp.ToString()
            + "\n\nStat points: \r\t\t\t" + PlayerManager.Instance.Stats.StatPoints.ToString()
            + "\n\nStrength: \r\t\t\t" + PlayerManager.Instance.Stats.Strength.ToString()
            + "\n\nDexterity: \r\t\t\t" + PlayerManager.Instance.Stats.Dexterity.ToString()
            + "\n\nIntelligence: \r\t\t\t" + PlayerManager.Instance.Stats.Intelligence.ToString()
            + "\n\nWisdom: \r\t\t\t" + PlayerManager.Instance.Stats.Wisdom.ToString()
            + "\n\nConstitution: \r\t\t\t" + PlayerManager.Instance.Stats.Constitution.ToString()
            + "\n\nCharisma: \r\t\t\t" + PlayerManager.Instance.Stats.Charisma.ToString()
            );
        statUpHandler.OnStarted();
    }

}
