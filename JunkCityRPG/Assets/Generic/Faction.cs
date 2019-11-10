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

    private void OnEnable() {
        factionEncountered = false;
        influence = 0;
    }

    //Hostile - Negative - Wary - Neutral - Friendly - Ally - Honoured
    public string GetFactionOpinion() {
        Debug.Log("opinion: " + influence);
        switch(Influence) {
            case int n when(n < -25 && n >= -35):
                return "Hostile";
            case int n when(n < -15 && n >= -25):
                return "Negative";
            case int n when(n < -5 && n >= -15):
                return "Wary";
            case int n when(n > 5 && n <= 15):
                return "Friendly";
            case int n when(n > 15 && n <= 25):
                return "Respected";
            case int n when(n > 25 && n <= 35):
                return "Honoured";
            default:
                return "neutral";
        }
    }
}
