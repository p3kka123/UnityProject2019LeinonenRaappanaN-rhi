using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumAmbushDialog : Dialog
{

    private State state;
    private bool thugsAttack;
    private bool enoughMoney;


    public enum State
    {
        start,
        criminalThreat,
        detailsOfSHIT,
        slumWork,
        giveMoney,
        intimidate,
        notEnoughMoney,
        end
    }

    // Start is called before the first frame update
    void Start() {
        Gamemanager.Instance.CurrentState = Gamemanager.GameState.Dialog;
        DialogManager.Instance.show(this);
        if(Inventory.Instance.Money >= 5)
            enoughMoney = true;

    }

    public override void NextLine() {

        if(enoughMoney)
            NextLineMoney();
        else
            NextLineNoMoney();

        if(state == State.start) {
            manager.ST("[As you are travelling towards the slum you encounter two men who seem hostile.]");
            state = State.criminalThreat;
        }
    }

    private void NextLineMoney() {
        DialogNode node;
        switch(state) {
            case State.criminalThreat:
                Camera.main.GetComponent<CameraFollow>().SetGOToFollow(gameObject);
                node = new DialogNode("Well, well, well. What do we have here? 'Aven't seen your face 'round these parts before. You'd better pay tribute to " +
                    "the Society for Habitual Infraction of Traditions or you might really get hurt, lad. The costs' five marks.","I've never heard of them before.","I'm heading to the slums to find some \"honest\" work.","[Give 5 marks]");
                HandleNode(node);
                break;
            case State.detailsOfSHIT:
                node = new DialogNode("Society for Habitual Infraction of Traditions, SHIT for short. We're the law 'round this part of the town, punk. Now give us your money!","[Intimidate] You'd better back off. I've made meat out of mightier men than you.","I'm heading to the slums to find some \"honest\" work.","[Give 5 marks]");
                HandleNode(node);
                break;
            case State.intimidate:
                int chance = Random.Range(1,20) + PlayerManager.Instance.Stats.Charisma / 10;
                print(chance);
                if(chance > 15) {
                    manager.ST("Whao, calm down, big guy! Clearly you are a capable fellow. We at SHIT always have a need for arms. If you're interested in work find our headquarters at the slums.");
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += -1;
                    QuestManager.Instance.AddQuest(new SlumIntro());
                    state = State.end;
                    break;
                } else {
                    node = new DialogNode("Yeah right, baby face. Now give us your money!","You'll regret this! [Attack]","[Give 5 marks].");
                    HandleNode(node);
                }
                break;
            case State.slumWork:
                if(QuestManager.Instance.FindQuest("It ain't much, but it's dishonest work") != null) {
                    manager.ST("I see, you're a man of the streets. You've got the look. If you're up for it, find our headquarters at the slums and we'll see what you're made of.");
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += 1;
                    Quest slum = QuestManager.Instance.FindQuest("It ain't much, but it's dishonest work");
                    slum.AdvanceQuestPhaseByOne();
                    state = State.end;
                } else {
                    node = new DialogNode("Yeah right, baby face. Now give us your money!","You'll regret this! [Attack]","[Give 5 marks]");
                    HandleNode(node);
                }
                break;
            case State.giveMoney:
                manager.ST("Thanks for your patronage, lad. You'd better behave yourself on our turf!");
                Inventory.Instance.Money -= 5;
                state = State.end;
                break;
            case State.end:
                FactionManager.Instance.FactionEncountered("Society for Habitual Infraction of Traditions");
                if(thugsAttack) {
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += -2;
                }
                manager.endConvo();
                break;
        }
    }

    private void NextLineNoMoney() {
        DialogNode node;
        switch(state) {
            case State.criminalThreat:
                Camera.main.GetComponent<CameraFollow>().SetGOToFollow(gameObject);
                node = new DialogNode("Well, well, well. What do we have here? 'Aven't seen your face 'round these parts before. You'd better pay tribute to " +
                    "the Society for Habitual Infraction of Traditions or you might really get hurt, lad. The costs' five marks.","I've never heard of them before.","I'm heading to the slums to find some \"honest\" work.","I don't have enough money.");
                HandleNode(node);
                break;
            case State.detailsOfSHIT:
                node = new DialogNode("Society for Habitual Infraction of Traditions, SHIT for short. We're the law 'round this part of the town, punk. Now give us your money!","[Intimidate] You'd better back off. I've made meat out of mightier men than you.","I'm heading to the slums to find some \"honest\" work.","I don't have enough money.");
                HandleNode(node);
                break;
            case State.intimidate:
                int chance = Random.Range(1,20) + PlayerManager.Instance.Stats.Charisma / 10;
                print(chance);
                if(chance > 15) {
                    manager.ST("Whao, calm down, big guy! Clearly you are a capable fellow. We at SHIT always have a need for arms. If you're interested in work find our headquarters at the slums.");
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += -1;
                    QuestManager.Instance.AddQuest(new SlumIntro());
                    state = State.end;
                    break;
                } else {
                    node = new DialogNode("Yeah right, baby face. Now give us your money!","You'll regret this! [Attack]","I don't have enough money.");
                    HandleNode(node);
                }
                break;
            case State.slumWork:
                if(QuestManager.Instance.FindQuest("It ain't much, but it's dishonest work") != null) {
                    manager.ST("I see, you're a man of the streets. You've got the look. If you're up for it, find our headquarters at the slums and we'll see what you're made of.");
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += 1;
                    Quest slum = QuestManager.Instance.FindQuest("It ain't much, but it's dishonest work");
                    slum.AdvanceQuestPhaseByOne();
                    state = State.end;
                } else {
                    node = new DialogNode("Yeah right, baby face. Now give us your money!","You'll regret this! [Attack]","I don't have enough money.");
                    HandleNode(node);
                }
                break;
            case State.notEnoughMoney:
                manager.ST("Then pay with your blood!");
                thugsAttack = true;
                state = State.end;
                break;
            case State.end:
                FactionManager.Instance.FactionEncountered("Society for Habitual Infraction of Traditions");
                if(thugsAttack) {
                    FactionManager.Instance.GetFaction("Society for Habitual Infraction of Traditions").Influence += -2;
                }
                manager.endConvo();
                break;
        }
    }

    public override void HandleQuestion(int ans) {
        if(enoughMoney)
            HandleQuestionMoney(ans);
        else
            HandleQuestionNoMoney(ans);

        
    }

    private void HandleQuestionNoMoney(int ans) {
        switch(state) {
            case State.criminalThreat:
                if(ans == 0)
                    state = State.detailsOfSHIT;
                else if(ans == 1)
                    state = State.slumWork;
                else
                    state = State.notEnoughMoney;
                break;
            case State.detailsOfSHIT:
                if(ans == 0)
                    state = State.intimidate;
                else if(ans == 1)
                    state = State.slumWork;
                else
                    state = State.notEnoughMoney;
                break;
            case State.intimidate:
                if(ans == 0) {
                    thugsAttack = true;
                    state = State.end;
                } else if(ans == 1)
                    state = State.notEnoughMoney;
                break;
            case State.slumWork:
                if(ans == 0) {
                    thugsAttack = true;
                    state = State.end;
                } else if(ans == 1)
                    state = State.notEnoughMoney;
                break;
        }
        NextLine();
    }

    private void HandleQuestionMoney(int ans) {
        switch(state) {
            case State.criminalThreat:
                if(ans == 0)
                    state = State.detailsOfSHIT;
                else if(ans == 1)
                    state = State.slumWork;
                else
                    state = State.giveMoney;
                break;
            case State.detailsOfSHIT:
                if(ans == 0)
                    state = State.intimidate;
                else if(ans == 1)
                    state = State.slumWork;
                else
                    state = State.giveMoney;
                break;
            case State.intimidate:
                if(ans == 0) {
                    thugsAttack = true;
                    state = State.end;
                } else if(ans == 1)
                    state = State.giveMoney;
                break;
            case State.slumWork:
                if(ans == 0) {
                    thugsAttack = true;
                    state = State.end;
                } else if(ans == 1)
                    state = State.giveMoney;
                break;
        }
        NextLine();
    }



}
