using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemDetailSetter : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI itemName;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected Button discardButton;


    private Item detailItem;

    public Item DetailItem { get => detailItem; set => detailItem = value; }


    public void Awake() {
        discardButton.onClick.AddListener(delegate { DiscardItem("testo"); });
    }

    public void SetItemName(string name) {
        itemName.text = name;
    }

    public void SetItemDesc(string desc) {
        description.text = desc;
    }

    public void DiscardItem(string gona) {
        Inventory.Instance.RemoveItemFromInventory(DetailItem);
        Inventory.Instance.OpenInventory();
    }

    public string GetItemName() {
        return itemName.text;
    }
    
}
