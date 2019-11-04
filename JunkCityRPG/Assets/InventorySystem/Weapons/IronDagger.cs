using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDagger : Weapon
{
    public IronDagger() {
        Value = 5;
        ItemName = "Iron Dagger";
        Range = 1;
        Arc = 1;
        AttackSpeed = 5;
        Damage = 3;
        Description = "An ordinary iron dagger. Crudely made but deadly in the right hands.";
    }
}
