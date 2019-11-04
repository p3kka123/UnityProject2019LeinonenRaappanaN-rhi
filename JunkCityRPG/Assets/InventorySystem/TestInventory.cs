using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{




    public List<Item> items;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Item item in items) {
            Inventory.Instance.AddItemToInventory(item);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
