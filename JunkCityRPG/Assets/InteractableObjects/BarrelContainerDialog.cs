using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelContainerDialog : Dialog
{

    string[] lines;
    int index;
    int choices = 0;
    string[] choiceText;
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

    override public void NextLine() {

        if(state == State.start) {
            manager.ST("An ordinary wooden barrel. Inside there is a vial of clear liquid");
            choiceText = new string[2];
            choiceText[0] = "Take it.";
            choiceText[1] = "Leave it.";
            manager.Question(2,choiceText);
        } else if(state == State.tookContents) {            
            manager.ST("You took the contents of the barrel.");
            List<Item> items = GetComponent<Container>().ItemsInContainer;
            foreach(Item item in items) {
                Inventory.Instance.AddItemToInventory(item);
            }
            contentsTaken = true;                
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
