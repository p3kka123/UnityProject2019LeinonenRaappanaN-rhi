using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : Weapon
{
    public ShortSword(GameObject model) {
        WeaponGO = model;
        Value = 5;
        ItemName = "Shortsword";
        Range = 1.2f;
        Arc = 1.2f;
        AttackSpeed = 3;
        Damage = 4;
        Description = "A standard weapon. Used in militias all around the content.";
        TwoHanded = false;
    }
}
