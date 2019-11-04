using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{

    private int value;

    public int Value { get => value; set => this.value = value; }
    public string ItemName { get => itemName; set => itemName = value; }
    public int AmountInInventory { get => amountInInventory; set => amountInInventory = value; }
    public string Description { get => description; set => description = value; }

    private string itemName;

    private int amountInInventory;

    private string description;

}
