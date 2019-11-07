using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Inventory : MonoBehaviour
{

    private static Inventory _instance;

    public static Inventory Instance { get { return _instance; } }


    private List<Item> inventoryItems = new List<Item>();
    

    private GameObject inventoryElementGrid;
    [SerializeField]
    private GameObject inventoryMenuItem;

    [SerializeField]
    private GameObject weaponDetails;
    [SerializeField]
    private GameObject consumableDetails;


    private WeaponDetailSetter wSetter;
    private ConsumableDetailSetter cSetter;

    private GameObject curDetail;
    private GameObject equippedWeaponGO;

    GameObject playerRightHandWeaponAnchor;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
            _instance = this;


        inventoryElementGrid = Gamemanager.Instance.InventoryGrid;
        playerRightHandWeaponAnchor = Gamemanager.Instance.PlayerRightHandAnchor;

        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        inventoryElementGrid = Gamemanager.Instance.InventoryGrid;
        playerRightHandWeaponAnchor = Gamemanager.Instance.PlayerRightHandAnchor;
    }

    public void AddItemToInventory(Item itemToAdd) {
        if (ContainsItem(itemToAdd.ItemName)) {
            int index = inventoryItems.IndexOf(itemToAdd);
            inventoryItems[index].AmountInInventory++;;
        } else {
            print(itemToAdd.ToString());
            itemToAdd.AmountInInventory++;
            inventoryItems.Add(itemToAdd);

        }
            
    }

    public void RemoveItemFromInventory(Item itemToRemove) {
        if(itemToRemove.ItemName == "Fist") return;
        if(itemToRemove.AmountInInventory == 1) 
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
        
        foreach (Transform child in inventoryElementGrid.transform) {
            
            Destroy(child.gameObject);
        }

        print("inventory size: " + inventoryItems.Count);

        if(wSetter != null) 
            Destroy(wSetter.gameObject);
        if(cSetter != null)
            Destroy(cSetter.gameObject);


        foreach (Item item in inventoryItems) {
            GameObject menuItem = Instantiate(inventoryMenuItem, inventoryElementGrid.transform);
            menuItem.GetComponentInChildren<TextMeshProUGUI>().text = item.ItemName + "   " + item.AmountInInventory;

            if(item is Weapon) {
                menuItem.GetComponent<Button>().onClick.AddListener(delegate { ShowWeaponDetail(item as Weapon); });
            } else if(item is Consumable) {//bugin
                menuItem.GetComponent<Button>().onClick.AddListener(delegate { ShowConsumableDetail(item as Consumable); });
            }
        }

    }

    public void EquipWeapon(Weapon weapon) {
        PlayerManager.Instance.PlayerEquipment.RightWeapon = weapon;
        PlayerManager.Instance.AttackHitBox.transform.localScale = new Vector3(weapon.Arc, 0.8f, weapon.Range);

        if(equippedWeaponGO != null) {
            Destroy(equippedWeaponGO);
        }
        equippedWeaponGO = Instantiate(weapon.WeaponGO);
        equippedWeaponGO.transform.SetParent(playerRightHandWeaponAnchor.transform);
        equippedWeaponGO.transform.localPosition = Vector3.zero;
        equippedWeaponGO.transform.localRotation = Quaternion.identity;
        
            

        print("Equipped " + weapon);
    }

    public void ShowWeaponDetail(Weapon weapon) {        
        if(wSetter == null || wSetter.GetItemName() != weapon.ItemName) {
            Destroy(curDetail);
            wSetter = Instantiate(weaponDetails,inventoryElementGrid.transform.root).GetComponentInChildren<WeaponDetailSetter>();
            curDetail = wSetter.gameObject;
            wSetter.DetailItem = weapon;
            wSetter.SetItemName(weapon.ItemName);
            wSetter.SetItemDamage((weapon.Damage).ToString());
            wSetter.SetItemDesc(weapon.Description);
            wSetter.SetItemSpeed((weapon.AttackSpeed).ToString());
            wSetter.SetRange((weapon.Range).ToString().Replace(',','.'));
        } else {
            Destroy(wSetter.gameObject);
        }       
    }


    public void ShowConsumableDetail(Consumable consumable) {        
        if(cSetter == null || cSetter.GetItemName() != consumable.ItemName) {
            Destroy(curDetail);
            cSetter = Instantiate(consumableDetails,inventoryElementGrid.transform.root).GetComponentInChildren<ConsumableDetailSetter>();
            cSetter.DetailItem = consumable;
            curDetail = cSetter.gameObject;
            cSetter.SetItemName(consumable.ItemName);
            cSetter.SetItemDesc(consumable.Description);
            cSetter.SetItemEffect(consumable.Effect);
        } else {
            Destroy(cSetter.gameObject);
        }
    }
}
