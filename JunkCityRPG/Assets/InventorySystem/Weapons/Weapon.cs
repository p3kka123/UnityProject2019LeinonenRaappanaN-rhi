using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{


    private int range;
    private int arc;
    private int attackSpeed;
    private int damage;

    public int Range { get => range; set => range = value; }
    public int Arc { get => arc; set => arc = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }


}
