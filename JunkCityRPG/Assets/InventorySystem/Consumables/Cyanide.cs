using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyanide : Consumable
{
    
    public Cyanide() {
        ItemName = "Cyanide";
        Value = 100;
        Description = "A Vial of clear liquid.";
        Effect = "Causes a swift death.";
    }

    public override void Consume() {
        PlayerManager.Instance.Stats.SetHealth(PlayerManager.Instance.Stats.CurrHealth - 1000);
    }
}
