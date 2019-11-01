using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialog : Dialog
{
    string[] lines;
    int index;
    int choices = 0;
    string[] choiceText;
    DialogManager manager;
    State state;

    public enum State
    {
        greet,
        info,
        quest,
        end,
    }

    public override void SetManager(DialogManager manager)
    {
        this.manager = manager;
    }

    override public void NextLine()
    {
        if (state == State.greet)
        {
            manager.ST("Hey, you. You're finally awake. You were trying to cross the border, right? Can I help you with anything?");
            choiceText = new string[2];
            choiceText[0] = "give money";
            choiceText[1] = "bye";
            manager.Question(2, choiceText);
            state = State.end;
        }
        else if (state == State.info)
        {
            manager.ST("Sorry, I dont have any money");
            state = State.end;
        }
        else if (state == State.quest)
        {

        }
        else if (state == State.end)
        {
            manager.endConvo();
            state = State.greet;
        }
    }

    override public void HandleQuestion(int ans)
    {
        if (ans == 0)
        {
            state = State.info;
        }
        else
        {
            state = State.end;
        }
    }
}
