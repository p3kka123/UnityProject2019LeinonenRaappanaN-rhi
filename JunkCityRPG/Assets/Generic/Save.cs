using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public string name;
    public int statPoints;
    public int exp;
    public int level;
    public int currHealth;
    public int currMana;
    public int health;
    public int mana;
    public int strength;
    public int dexterity;
    public int intelligence;
    public int wisdom;
    public int constitution;
    public int charisma;

    public int money;

    //public List<Item> items;
    public Dictionary<string, int> items = new Dictionary<string, int>();

    //public PlayerManager.Equipment equipment;

    public List<FactionData> factions = new List<FactionData>();

    public Dictionary<PlayerManager.Equipment.EquipmentSlot,string> equipment = new Dictionary<PlayerManager.Equipment.EquipmentSlot,string>();

    public List<Quest> activeQuests;
    public List<Quest> completedQuests;

    public string currScene;

    [System.Serializable]
    public struct FactionData
    {
        public string name;
        public int influence;
        public bool encounterState;

        public FactionData(string _name, int _influence, bool state) {
            name = _name;
            influence = _influence;
            encounterState = state;
        }
    }
}
