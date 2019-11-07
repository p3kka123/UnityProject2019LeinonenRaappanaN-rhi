using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{



    public virtual void Interact() {

    }

    //protected void OnMouseOver() {
    //    print("Mouse over " + gameObject);
    //}

    protected void OnMouseEnter() {
        Cursor.SetCursor(Gamemanager.Instance.InteractableCursor, Vector2.zero, CursorMode.Auto);
    }

    protected void OnMouseExit() {
        Cursor.SetCursor(Gamemanager.Instance.BaseCursor,Vector2.zero,CursorMode.Auto);
    }

}
