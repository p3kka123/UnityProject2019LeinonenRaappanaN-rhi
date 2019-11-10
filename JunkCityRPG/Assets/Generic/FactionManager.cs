using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionManager : MonoBehaviour
{
    [SerializeField]
    private List<Faction> factions = new List<Faction>();

    public List<Faction> Factions { get => factions;}

    private void Start() {

        foreach(Faction faction in Factions) {
            print(faction.FactionName + " " + faction.GetFactionOpinion());
        }
    }

    public void FactionEncountered(string factionName) {
        foreach(Faction faction in Factions) {
            if(faction.FactionName == factionName) {
                faction.FactionEncountered = true;
                Gamemanager.Instance.DisplayNotification("Faction encountered: " + factionName);
                return;
            }
        }
        Debug.LogWarning("Couldn't set faction encountered. " + factionName + "was not found.");
    }

    public Faction GetFaction(string factionName) {
        foreach(Faction faction in Factions) {
            if(faction.FactionName == factionName) {                                
                return faction;
            }
        }
        Debug.LogWarning("Couldn't set faction encountered. " + factionName + "was not found.");
        return null;        
    }

}
