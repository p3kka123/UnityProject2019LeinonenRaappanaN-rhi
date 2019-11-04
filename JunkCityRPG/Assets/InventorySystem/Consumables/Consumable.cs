using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : Item
{ 

    private string effect;

    public string Effect { get => effect; set => effect = value; }

    public abstract void Consume();

}
