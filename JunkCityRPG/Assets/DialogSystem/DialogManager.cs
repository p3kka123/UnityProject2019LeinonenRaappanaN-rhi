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
    public TextAsset textFile;
    string[] lines;
    int index;
    Dialog dialog;

    void OnEnable()
    {
        lines = Regex.Split(textFile.text, "\n");
        dialog = new Dialog(lines);
        text.text = dialog.GetLine(0);
        index = 1;
    }

    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (index != dialog.GetLineAmount())
        {
            text.text = dialog.GetLine(index);
            index++;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
