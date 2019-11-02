using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNode
{

    public string text;
    public string[] questions;

    public DialogNode(string _text, string question1)
    {
        text = _text;
        questions = new string[1];
        questions[0] = question1;
    }

    public DialogNode(string _text, string question1, string question2)
    {
        text = _text;
        questions = new string[2];
        questions[0] = question1;
        questions[1] = question2;
    }

    public DialogNode(string _text, string question1, string question2, string question3)
    {
        text = _text;
        questions = new string[3];
        questions[0] = question1;
        questions[1] = question2;
        questions[2] = question3;
    }

}
