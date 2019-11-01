using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    string[] lines;
    int choices = 0;
    string[] choiceText;

    public Dialog(string[] lines)
    {
        this.lines = lines;
    }

    public Dialog(string[] lines, int choices, string[] choiceText)
    {
        this.lines = lines;
        this.choices = choices;
        this.choiceText = choiceText;
    }

    public string GetLine(int index)
    {
        return lines[index];
    }

    public int GetLineAmount()
    {
        return lines.Length;
    }

}
