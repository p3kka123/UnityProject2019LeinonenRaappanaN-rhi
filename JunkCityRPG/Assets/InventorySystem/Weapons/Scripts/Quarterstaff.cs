using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarterstaff : Weapon
{
    public Quarterstaff(GameObject model) {
        WeaponGO = model;
        Value = 5;
        ItemName = "Quarterstaff";
        Range = 2f;
        Arc = 0.6f;
        AttackSpeed = 3;
        Damage = 3;
        Description = "A long stout staff made from wood. Favored by travellers.";
        TwoHanded = true;
    }
}
