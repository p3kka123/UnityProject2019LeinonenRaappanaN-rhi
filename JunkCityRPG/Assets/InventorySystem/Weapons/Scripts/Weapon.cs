using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{

    private GameObject weaponGO;
    private float range;
    private float arc;
    private int attackSpeed;
    private int damage;
    private bool twoHanded;

    public float Range { get => range; set => range = value; }
    public float Arc { get => arc; set => arc = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public bool TwoHanded { get => twoHanded; set => twoHanded = value; }
    public GameObject WeaponGO { get => weaponGO; set => weaponGO = value; }
}
