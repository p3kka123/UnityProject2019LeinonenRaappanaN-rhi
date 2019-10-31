using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dialog : MonoBehaviour, IPointerClickHandler
{

    public Text text;
    public TextAsset textFile;
    string[] lines;
    int index;

    void OnEnable()
    {
        lines = Regex.Split(textFile.text, "\n");
        text.text = lines[0];
        index = 1;
    }

    public void show()
    {
        this.gameObject.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (index != lines.Length)
        {
            text.text = lines[index];
            index++;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        //throw new System.NotImplementedException();
    }
}
