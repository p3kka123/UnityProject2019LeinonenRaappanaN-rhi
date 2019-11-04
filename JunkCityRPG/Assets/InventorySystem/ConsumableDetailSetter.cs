using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsumableDetailSetter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI effect;
    [SerializeField] TextMeshProUGUI description;

    public void SetItemName(string _name) {
        itemName.text = _name;
    }

    public string GetItemName() {
        return itemName.text;
    }

    public void SetItemEffect(string _effect) {
        effect.text += " " + _effect;
    }
    public void SetItemDesc(string desc) {
        description.text = desc;
    }
}
