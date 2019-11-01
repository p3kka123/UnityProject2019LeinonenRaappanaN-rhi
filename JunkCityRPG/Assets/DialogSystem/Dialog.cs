using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog
{
    string[] lines;
    int index;
    int choices = 0;
    string[] choiceText;
    DialogManager manager;
    State state;

    public enum State {
        greet,
        info,
        quest,
        end,

    }

    public Dialog(DialogManager manager) {
        this.manager = manager;
        this.state = State.greet;
    }

    public void NextLine() {
        if (state == State.greet) {
            manager.ST("Hey, you. You're finally awake. You were trying to cross the border, right? Can I help you with anything");
            state = State.end;
        } else if (state == State.info) {

        }else if(state == State.quest) {

        }else if(state == State.end) {
            manager.endConvo();
            state = State.greet;
        }
    }

}
