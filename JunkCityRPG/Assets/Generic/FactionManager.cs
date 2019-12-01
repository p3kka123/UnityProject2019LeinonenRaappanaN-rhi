using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactionManager : MonoBehaviour
{
    private static FactionManager _instance;
    public static FactionManager Instance { get { return _instance; } }

    public List<Faction> Factions { get => factions; set => factions = value; }

    [SerializeField]
    private List<Faction> factions = new List<Faction>();


    private void Start() {

        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this);

        //foreach(Faction faction in Factions) {
        //    print(faction.FactionName + " " + faction.GetFactionOpinion());
        //}
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
        Debug.LogWarning(factionName + "was not found.");
        return null;        
    }

}
