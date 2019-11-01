using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{

    private Dialog dialog;

    [SerializeField]
    private List<string> itemsInContainer;

    private void Awake() {
        dialog = GetComponent<Dialog>();
    }


    public override void Interact() {
        DialogManager.Instance.show(dialog);
    }
}
