using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelContainerDialog : Dialog
{

    string[] lines;
    int index;
    int choices = 0;
    string[] choiceText;
    DialogManager manager;
    State state;

    bool contentsTaken;

    public enum State
    {
        start,
        tookContents,
        leftContents,
        contentsTaken,
        end
    }

    public override void SetManager(DialogManager manager) {
        this.manager = manager;
    }

    override public void NextLine() {

        if(state == State.start) {
            manager.ST("An ordinary wooden barrel. Inside there is a vial of clear liquid");
            choiceText = new string[2];
            choiceText[0] = "Take it.";
            choiceText[1] = "Leave it.";
            manager.Question(2,choiceText);
        } else if(state == State.tookContents) {
            SlobodansHonor honor = (SlobodansHonor)QuestManager.Instance.FindQuest("Slobodan's Honor");
            if(honor == null) {
                manager.ST("You have no use for that.");
            } else {
                manager.ST("You took the contents of the barrel.");
                contentsTaken = true;
                honor.PlayerHasCyanide = true;
            }            
            state = State.end;
        } else if(state == State.leftContents) {
            manager.ST("You left the contents of the barrel be.");
            state = State.end;
        } else if(state == State.contentsTaken) {
            manager.ST("Empty.");
            state = State.end;
        } else if(state == State.end) {
            if(!contentsTaken)  
                state = State.start;
            else
                state = State.contentsTaken;
            manager.endConvo();
        }
    }


    override public void HandleQuestion(int ans) {

        if(ans == 0) {
            state = State.tookContents;
        } else {
            state = State.leftContents;
        }
    }
}
