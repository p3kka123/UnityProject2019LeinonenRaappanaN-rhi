using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{




    // Start is called before the first frame update
    void Start()
    {
        Cyanide cyanide = new Cyanide();
        Inventory.Instance.AddItemToInventory(cyanide);

        IronDagger dagger = new IronDagger();
        Inventory.Instance.AddItemToInventory(dagger);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
