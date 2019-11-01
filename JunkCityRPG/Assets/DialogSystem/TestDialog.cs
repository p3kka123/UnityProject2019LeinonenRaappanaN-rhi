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
    SlobodansHonor slobodansHonorQuest;

    bool questAccepted;



    public enum State
    {
        greet,
        accept,
        decline,
        end,
        greetAccepted,
        giveCyanide,
        dontGiveCyanide,
        givenCyanide
    }

    public override void SetManager(DialogManager manager)
    {
        this.manager = manager;
    }

    override public void NextLine()
    {
        if(questAccepted) {
            QuestAcceptedDialog();
        } else {
            QuestNotAcceptedDialog();
        }
    }

    private void QuestAcceptedDialog() {
        if(state == State.greetAccepted) {
            manager.ST("Do you have the cyanide!?");
            choiceText = new string[2];
            choiceText[0] = "Yes, here you go.";
            choiceText[1] = "No, sorry.";
            manager.Question(2,choiceText);
            state = State.end;
        } else if(state == State.giveCyanide) {
            if(slobodansHonorQuest.PlayerHasCyanide) {
                manager.ST("How wonderful! I'd like you to come to the city courthouse later today, my friend.");
                GetComponent<Animator>().SetTrigger("QuestComplete");
                transform.position = new Vector3(transform.position.x, transform.position.y-2, transform.position.z);
            }                
            else {
                manager.ST("But you have no cyanide! Come back to me when you find some.");
            }               
            state = State.end;
        } else if(state == State.dontGiveCyanide) {
            manager.ST("Well what are you waiting for? Find me some cyanide.");
            state = State.end;            
        } else if(state == State.end) {
            manager.endConvo();
            if(!slobodansHonorQuest.PlayerHasCyanide) {
                state = State.greetAccepted;
            } else {
                state = State.givenCyanide;
            }            
        } else if(state == State.givenCyanide) {
            manager.ST("...");
            state = State.end;           
        }
    }

    private void QuestNotAcceptedDialog() {
        if(state == State.greet) {
            manager.ST("Hey there traveller. Would you be so kind as to find me a vial of cyanide?");
            choiceText = new string[2];
            choiceText[0] = "Sure, I'd love to help.";
            choiceText[1] = "Maybe later.";
            manager.Question(2,choiceText);
            state = State.end;
        } else if(state == State.accept) {
            manager.ST("How wonderful! Be sure to come back with the cyanide.");
            state = State.end;
        } else if(state == State.decline) {
            manager.ST("Thats too bad. Well, I'm here if you change your mind!");
            state = State.end;
        } else if(state == State.end) {
            if(!questAccepted) {
                slobodansHonorQuest = new SlobodansHonor();
                QuestManager.Instance.AddQuest(slobodansHonorQuest);
                manager.endConvo();
                state = State.greetAccepted;
                questAccepted = true;
                print("Quest accepted: " + slobodansHonorQuest.GetQuestName());
            }  
        }
    }

    override public void HandleQuestion(int ans)
    {

        if(!questAccepted) {
            if(ans == 0) {
                state = State.accept;
            } else {
                state = State.decline;
            }
        } else {
            if(ans == 0) {
                state = State.giveCyanide;
            } else {
                state = State.dontGiveCyanide;
            }
        }
        
    }
}
