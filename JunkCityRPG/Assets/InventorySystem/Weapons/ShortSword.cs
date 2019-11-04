using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSword : Weapon
{
    public ShortSword() {
        Value = 5;
        ItemName = "Shortsword";
        Range = 1.5f;
        Arc = 1.5f;
        AttackSpeed = 3;
        Damage = 4;
        Description = "A standard weapon. Used in militias all around the content.";
    }
}
