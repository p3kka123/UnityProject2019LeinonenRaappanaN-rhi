using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog : MonoBehaviour
{
    public abstract void NextLine();

    public abstract void HandleQuestion(int ans);

    public abstract void SetManager(DialogManager manager);
}
