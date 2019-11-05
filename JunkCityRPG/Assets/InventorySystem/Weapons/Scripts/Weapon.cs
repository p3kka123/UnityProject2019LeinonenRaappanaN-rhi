using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Weapon",menuName = "Weapon Data",order = 51)]
public class Weapon : Item
{

    [SerializeField] private GameObject weaponGO;
    [SerializeField] private float range;
    [SerializeField] private float arc;
    [SerializeField] private int attackSpeed;
    [SerializeField] private int damage;
    [SerializeField] private bool twoHanded;

    public float Range { get => range; set => range = value; }
    public float Arc { get => arc; set => arc = value; }
    public int AttackSpeed { get => attackSpeed; set => attackSpeed = value; }
    public int Damage { get => damage; set => damage = value; }
    public bool TwoHanded { get => twoHanded; set => twoHanded = value; }
    public GameObject WeaponGO { get => weaponGO; set => weaponGO = value; }
}
