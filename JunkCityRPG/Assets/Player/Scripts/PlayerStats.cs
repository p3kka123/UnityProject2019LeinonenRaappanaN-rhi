using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private float health;
    private float mana;
    private float strength;
    private float dexterity;
    private float intelligence;
    private float wisdom;
    private float constitution;
    private float charisma;


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

}
