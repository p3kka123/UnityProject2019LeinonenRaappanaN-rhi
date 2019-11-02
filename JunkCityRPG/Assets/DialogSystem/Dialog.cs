using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    public DialogManager manager;

    public void HandleNode(DialogNode node)
    {
        manager.ST(node.text);
        manager.Question(node.questions.Length, node.questions);
    }

    public abstract void NextLine();

    public abstract void HandleQuestion(int ans);

    public void SetManager(DialogManager manager)
    {
        this.manager = manager;
    }
}
