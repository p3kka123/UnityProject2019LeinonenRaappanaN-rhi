using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }


    private List<Item> inventoryItems = new List<Item>();
    

    [SerializeField]
    private GameObject inventoryElementGrid;
    [SerializeField]
    private GameObject inventoryMenuItem;

    [SerializeField]
    private GameObject weaponDetails;

    private WeaponDetailSetter wSetter;


    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    //void Update()
    //{

    //}

    public void AddItemToInventory(Item itemToAdd) {
        if(ContainsItem(itemToAdd.ItemName)) {
            int index = inventoryItems.IndexOf(itemToAdd);
            inventoryItems[index].AmountInInventory++;;
        } else {
            itemToAdd.AmountInInventory++;
            inventoryItems.Add(itemToAdd);

        }
            
    }

    public void RemoveItemFromInventory(Item itemToRemove) {
        if(itemToRemove.AmountInInventory == 0) 
            inventoryItems.Remove(itemToRemove);
        else
            itemToRemove.AmountInInventory--;
    }

    public bool ContainsItem(string itemToCheck) {
        foreach(Item item in inventoryItems) {
            if(item.ItemName == itemToCheck)
                return true;
        }
        return false;
    }

    public Item GetItemFromInventory(Item itemToGet) {
        int index = inventoryItems.IndexOf(itemToGet);
        return inventoryItems[index];
    }

    public void OpenInventory() {

        foreach(Transform child in inventoryElementGrid.transform) {
            Destroy(child.gameObject);
        }

        if(wSetter != null) 
            Destroy(wSetter.gameObject);


        foreach(Item item in inventoryItems) {
            GameObject menuItem = Instantiate(inventoryMenuItem, inventoryElementGrid.transform);
            menuItem.GetComponentInChildren<Text>().text = item.ItemName + "   " + item.AmountInInventory;

            if(item is Weapon) {
                menuItem.GetComponent<Button>().onClick.AddListener(delegate { ShowWeaponDetail(item as Weapon); });
            }
        }

    }

    public void ShowWeaponDetail(Weapon weapon) {        
        if(wSetter == null) {
            print("Setting weapon shit");
            wSetter = Instantiate(weaponDetails,inventoryElementGrid.transform.root).GetComponentInChildren<WeaponDetailSetter>();
            wSetter.SetItemName(weapon.ItemName);
            wSetter.SetItemDamage((weapon.Damage).ToString());
            wSetter.SetItemDesc(weapon.Description);
            wSetter.SetItemSpeed((weapon.AttackSpeed).ToString());
            wSetter.SetRange((weapon.Range).ToString());
        } else {
            Destroy(wSetter.gameObject);
            print("Already made");
        }
        
    }
}
