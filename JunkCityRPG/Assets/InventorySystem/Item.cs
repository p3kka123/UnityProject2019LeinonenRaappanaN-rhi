using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New Item",menuName = "Item Data",order = 51)]
public class Item : ScriptableObject
{
    [SerializeField] private int value;

    public int Value { get => value; set => this.value = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public int AmountInInventory { get => amountInInventory; set => amountInInventory = value; }
    public string Description { get => description; set => description = value; }

    [SerializeField] private string itemName;

    [SerializeField] private int amountInInventory = 0;

    [SerializeField] private string description;

    private void OnEnable() {
        //amountInInventory = 0;
    }

}
