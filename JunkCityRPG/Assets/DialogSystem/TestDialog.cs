using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialog : Dialog
{
    DialogNode node;
    string[] lines;
    int index;
    int choices = 0;
    string[] choiceText;
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
            node = new DialogNode("Do you have the cyanide!?", "Yes, here you go.", "No, sorry.");
            HandleNode(node);
            state = State.end;
        } else if(state == State.giveCyanide) {
            if(slobodansHonorQuest.PlayerHasCyanide) {
                manager.ST("How wonderful! I'd like you to come to the city courthouse later today, my friend.");
                GetComponent<Animator>().SetTrigger("QuestComplete");
                slobodansHonorQuest.GiveCyanide();
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
            if(!slobodansHonorQuest.PlayerHasCyanide || !slobodansHonorQuest.GaveSlobodanCyanide) {
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
            node = new DialogNode("Hey there traveller. Would you be so kind as to find me a vial of cyanide?", "Sure, I'd love to help.", "Maybe later.");
            HandleNode(node);
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
