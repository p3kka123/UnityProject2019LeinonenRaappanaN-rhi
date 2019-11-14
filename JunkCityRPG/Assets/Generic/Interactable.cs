﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    protected Dialog dialog;

    private GameObject tooltip;

    private void Awake() {
        dialog = GetComponent<Dialog>();
    }

    public virtual void Interact() {
        if(dialog != null)
            DialogManager.Instance.show(dialog);
    }

    private void Start() {
        tooltip = Gamemanager.Instance.ToolTip;
    }

    protected void OnMouseOver() {
        tooltip.transform.position = Input.mousePosition + new Vector3(10,15);
    }

    protected void OnMouseEnter() {
        tooltip.SetActive(true);
        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
        if(gameObject.tag == "Enemy")
            Cursor.SetCursor(Gamemanager.Instance.AttackCursor,Vector2.zero,CursorMode.Auto);
        else
            Cursor.SetCursor(Gamemanager.Instance.InteractableCursor, Vector2.zero, CursorMode.Auto);
    }

    protected void OnMouseExit() {
        Cursor.SetCursor(Gamemanager.Instance.BaseCursor,Vector2.zero,CursorMode.Auto);
        tooltip.SetActive(false);
    }

}
