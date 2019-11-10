using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortHoboDialog : Dialog
{

    private bool givenMoney;
    private bool gulag;

    private State state;

    public enum State
    {
        greet,
        hoboIntroduction,
        giveMoney,
        accuse,
        gulag,
        end
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void NextLine() {
        DialogNode node;
        switch(state) {
            case State.greet:
                node = new DialogNode("[You encounter a suspicious looking man going through the contents of a cart.]","What are you doing?","[Leave him be.]");
                HandleNode(node);
                break;
            case State.hoboIntroduction:
                node = new DialogNode("I'm just a poor ol´ homeless feller. I need to fill my belly with something, you know. Spare some change mister?","Here you go, good sir.","So you're stealing? Off to the gulag you go.","[Leave him be.]");
                HandleNode(node);
                break;
            case State.giveMoney:
                manager.ST("Thank the heavens for your kindness sir!");               
                state = State.end;
                break;
            case State.accuse:
                node = new DialogNode("This cart been here for days! It's abandoned I tell you. Please mister, be kind to me.","I'll let you off the hook this time.","[Call authorities]","[Attack]");
                HandleNode(node);
                break;
            case State.gulag:
                manager.ST("You won't take me alive!");
                gulag = true;
                state = State.end;
                break;
            case State.end:
                if(givenMoney || !gulag)
                    state = State.giveMoney;
                else if(gulag)
                    state = State.gulag;
                else 
                    state = State.greet;
                manager.endConvo();
                break;
        }   
    }

    public override void HandleQuestion(int ans) {
        switch(state) {
            case State.greet:
                if(ans == 0) 
                    state = State.hoboIntroduction;
                else
                    state = State.end;
                break;
            case State.hoboIntroduction:
                if(ans == 0) {
                    state = State.giveMoney;
                    givenMoney = true;
                } else if(ans == 1) {
                    state = State.accuse;
                } else
                    state = State.end;
                break;
            case State.accuse:
                if(ans == 0) {
                    state = State.giveMoney;
                } else if(ans == 1) {
                    state = State.gulag;
                } else
                    state = State.gulag;
                break;
        }
        NextLine();
    }
}
