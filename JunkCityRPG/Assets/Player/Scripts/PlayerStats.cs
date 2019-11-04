using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private string name;
    private int statPoints;
    private int exp;
    private int level;
    private int currHealth;
    private int currMana;
    private int health;
    private int mana;
    private int strength;
    private int dexterity;
    private int intelligence;
    private int wisdom;
    private int constitution;
    private int charisma;

    public int Dexterity { get => dexterity; set => dexterity = value; }
    public int Intelligence { get => intelligence; set => intelligence = value; }
    public int Wisdom { get => wisdom; set => wisdom = value; }
    public int Constitution { get => constitution; set => constitution = value; }
    public int Charisma { get => charisma; set => charisma = value; }
    public int Level { get => level; set => level = value; }
    public int Exp { get => exp; set => exp = value; }
    public string Name { get => name; set => name = value; }
    public int CurrHealth { get => currHealth; set => currHealth = value; }
    public int CurrMana { get => currMana; set => currMana = value; }
    public int StatPoints { get => statPoints; set => statPoints = value; }
    public int Health { get => health; set => health = value; }
    public int Mana { get => mana; set => mana = value; }
    public int Strength { get => strength; set => strength = value; }

    public PlayerStats(int _health,int _mana,int _strength) {
        Health = _health;
        Mana = _mana;
        Strength = _strength;
    }


    public void GetExp(int _exp)
    {
        exp += _exp;
        if (exp > 100)
        {
            level++;
            statPoints += 5;
            exp -= 100;
        }
    }

}
