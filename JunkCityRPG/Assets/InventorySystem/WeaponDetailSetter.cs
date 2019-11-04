using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponDetailSetter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI damage;
    [SerializeField] TextMeshProUGUI range;
    [SerializeField] TextMeshProUGUI attackSpeed;
    [SerializeField] TextMeshProUGUI description;


    public string GetItemName() {
        return itemName.text;
    }

    public void SetItemName(string name) {
        itemName.text = name;
    }
    public void SetItemDamage(string dmg) {
        damage.text += " " + dmg;
    }
    public void SetRange(string _range) {
        range.text += " " + _range;
    }
    public void SetItemSpeed(string speed) {
        attackSpeed.text += " " + speed;
    }
    public void SetItemDesc(string desc) {
        description.text = desc;
    }

}
