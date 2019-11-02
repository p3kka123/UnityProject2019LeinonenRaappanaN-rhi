using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private string name;
    private int statPoints;
    private int exp;
    private int level;
    private float currHealth;
    private float currMana;
    private float health;
    private float mana;
    private float strength;
    private float dexterity;
    private float intelligence;
    private float wisdom;
    private float constitution;
    private float charisma;

    public float Dexterity { get => dexterity; set => dexterity = value; }
    public float Intelligence { get => intelligence; set => intelligence = value; }
    public float Wisdom { get => wisdom; set => wisdom = value; }
    public float Constitution { get => constitution; set => constitution = value; }
    public float Charisma { get => charisma; set => charisma = value; }
    public int Level { get => level; set => level = value; }
    public int Exp { get => exp; set => exp = value; }
    public string Name { get => name; set => name = value; }
    public float CurrHealth { get => currHealth; set => currHealth = value; }
    public float CurrMana { get => currMana; set => currMana = value; }
    public int StatPoints { get => statPoints; set => statPoints = value; }

    public PlayerStats(float _health, float _mana, float _strength) {
        health = _health;
        mana = _mana;
        strength = _strength;
    }
    public void SetHealth(float _health) {
        health = _health;
    }

    public float GetHealth() {
        return health;
    }

    public void SetMana(float _mana) {
        mana = _mana;
    }

    public float GetMana() {
        return mana;
    }

    public void SetStrength(float _stren) {
        strength = _stren;
    }

    public float GetStrength() {
        return strength;
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
