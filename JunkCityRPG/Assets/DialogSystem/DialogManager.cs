using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager : MonoBehaviour, IPointerClickHandler
{

    public Text text;
    string[] lines;
    int index;
    Dialog dialog;

    void OnEnable()
    {
        //lines = Regex.Split(textFile.text, "\n");
        dialog = new Dialog(this);
        //text.text = dialog.GetLine(0);
        //index = 1;
    }

    public void show()
    {
        this.gameObject.SetActive(true);
        dialog.NextLine();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        dialog.NextLine();
    }

    public void ST(string text) {
        this.text.text = text;
    }

    public void endConvo() {
        this.gameObject.SetActive(false);
    }

}
