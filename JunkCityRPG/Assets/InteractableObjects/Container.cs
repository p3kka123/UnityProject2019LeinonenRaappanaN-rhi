using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{


    [SerializeField]
    private List<Item> itemsInContainer;

    public List<Item> ItemsInContainer { get => itemsInContainer; set => itemsInContainer = value; }


}
