using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{

    private Dialog dialog;

    [SerializeField]
    private List<Item> itemsInContainer;

    public List<Item> ItemsInContainer { get => itemsInContainer; set => itemsInContainer = value; }

    private void Awake() {
        dialog = GetComponent<Dialog>();
    }


    public override void Interact() {
        DialogManager.Instance.show(dialog);
    }
}
