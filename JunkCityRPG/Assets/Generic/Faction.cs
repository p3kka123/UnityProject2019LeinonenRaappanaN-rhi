using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New Faction",menuName = "Faction",order = 51)]
public class Faction : ScriptableObject
{
    [SerializeField] private string factionName;
    [SerializeField] private int influence;
    private bool factionEncountered;

    public Faction(string name, int _influence) {
        FactionName = name;
        Influence = _influence;
    }

    public string FactionName { get => factionName; set => factionName = value; }
    public int Influence { get => influence; set => influence = value; }
    public bool FactionEncountered { get => factionEncountered; set => factionEncountered = value; }


    //Hostile - Negative - Wary - Neutral - Friendly - Ally - Honoured
    public string GetFactionOpinion() {
        switch(Influence) {
            case int n when(n < -20 && n >= -30):
                return "Hostile";
            case int n when(n < -10 && n >= -20):
                return "Negative";
            case int n when(n < 0 && n >= -10):
                return "Wary";
            case int n when(n > 0 && n <= 10):
                return "Friendly";
            case int n when(n > 10 && n <= 20):
                return "Respected";
            case int n when(n > 20 && n <= 30):
                return "Honoured";
            default:
                return "neutral";
        }
    }
}
