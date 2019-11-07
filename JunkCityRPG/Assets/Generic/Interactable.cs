using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interactable : MonoBehaviour
{

    private GameObject tooltip;



    public virtual void Interact() {

    }

    private void Start() {
        tooltip = Gamemanager.Instance.ToolTip;
    }

    protected void OnMouseOver() {
        tooltip.transform.position = Input.mousePosition + new Vector3(10,10);
    }

    protected void OnMouseEnter() {
        tooltip.SetActive(true);
        tooltip.GetComponentInChildren<TextMeshProUGUI>().text = gameObject.name;
        Cursor.SetCursor(Gamemanager.Instance.InteractableCursor, Vector2.zero, CursorMode.Auto);
    }

    protected void OnMouseExit() {
        Cursor.SetCursor(Gamemanager.Instance.BaseCursor,Vector2.zero,CursorMode.Auto);
        tooltip.SetActive(false);
    }

}
