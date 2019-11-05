using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "Cyanide",menuName = "Consumables/Cyanide",order = 51)]
public class Cyanide : Consumable
{
    
    public Cyanide() {
        ItemName = "Cyanide";
        Value = 100;
        Description = "A Vial of clear liquid.";
        Effect = "Causes a swift death.";
    }

    public override void Consume() {
        PlayerManager.Instance.Stats.Health = PlayerManager.Instance.Stats.CurrHealth - 1000;
    }
}
