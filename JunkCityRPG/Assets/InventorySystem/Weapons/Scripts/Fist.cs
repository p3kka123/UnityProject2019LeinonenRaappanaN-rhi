using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Weapon
{


    public Fist() {
        Value = 0;
        ItemName = "Fist";
        Range = 0.8f;
        Arc = 0.8f;
        AttackSpeed = 5;
        Damage = 0;
        Description = "A curse will not strike out an eye, unless the fist go with it.";
        TwoHanded = false;
    }

    
}
