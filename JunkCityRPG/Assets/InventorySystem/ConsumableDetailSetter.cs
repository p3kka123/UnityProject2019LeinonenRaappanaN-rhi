using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConsumableDetailSetter : ItemDetailSetter
{

    [SerializeField] TextMeshProUGUI effect;

    public void SetItemEffect(string _effect) {
        effect.text += " " + _effect;
    }
}
