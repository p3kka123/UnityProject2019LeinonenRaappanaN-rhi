using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{

    public GameObject swordGO;
    public GameObject quarterstaffGO;
    public GameObject daggerGO;

    // Start is called before the first frame update
    void Start()
    {
        Cyanide cyanide = new Cyanide();
        Inventory.Instance.AddItemToInventory(cyanide);

        IronDagger dagger = new IronDagger(daggerGO);
        Inventory.Instance.AddItemToInventory(dagger);

        ShortSword sword = new ShortSword(swordGO);
        Inventory.Instance.AddItemToInventory(sword);

        Quarterstaff staff = new Quarterstaff(quarterstaffGO);
        Inventory.Instance.AddItemToInventory(staff);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
