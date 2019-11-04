using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarterstaff : Weapon
{
    public Quarterstaff() {
        Value = 5;
        ItemName = "Quarterstaff";
        Range = 4f;
        Arc = 1f;
        AttackSpeed = 3;
        Damage = 3;
        Description = "A long stout staff made from wood. Favored by travellers.";
    }
}
