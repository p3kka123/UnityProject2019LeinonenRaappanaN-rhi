using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    [SerializeField]
    private Dialog dialog;

    private void Awake() {
        //dialog = GetComponent<Dialog>();
    }

    public override void Interact() {
        //DialogManager.Instance.show(dialog);
    }
}
