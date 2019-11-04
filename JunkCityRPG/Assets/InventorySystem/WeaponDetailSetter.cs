using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WeaponDetailSetter : ItemDetailSetter
{

    [SerializeField] private TextMeshProUGUI damage;
    [SerializeField] private TextMeshProUGUI range;
    [SerializeField] private TextMeshProUGUI attackSpeed;

    [SerializeField] private Button equipButton;


    public void Awake() {
        discardButton.onClick.AddListener(delegate { DiscardItem("testo"); });
        equipButton.onClick.AddListener(delegate { EquipThisWeapon(DetailItem as Weapon); });
        print(GetComponentInChildren<TextMeshProUGUI>());
    }

    public void EquipThisWeapon(Weapon weapon) {
        Inventory.Instance.EquipWeapon(weapon);
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




}
