using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Dialog
{
    public abstract void NextLine();

    public abstract void HandleQuestion(int ans);
}
