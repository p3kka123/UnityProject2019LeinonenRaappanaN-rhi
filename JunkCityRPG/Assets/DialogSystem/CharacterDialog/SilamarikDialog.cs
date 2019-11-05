using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilamarikDialog : Dialog
{
    private int kvl;
    private int slum;
    private int guard;
    private DialogNode node;
    [SerializeField]
    private InputField inputField;
    State state;

    SlumIntro slumIntroQuest;
    KVLIntro kvlIntroQuest;
    GuardIntro guardIntroQuest;

    [SerializeField]
    private List<Weapon> starterWeapons;

    public enum State
    {
        greet,
        askName,
        question1,
        question2,
        question3,
        question4,
        kvl,
        slum,
        guard,
        lastline,
        end,
    }

    private void Update()
    {
        if(state == State.askName && Input.GetKeyDown(KeyCode.Return) && inputField.text.Length != 0)
        {
            inputField.gameObject.SetActive(false);
            PlayerManager.Instance.Stats.Name = inputField.text;
            state = State.question1;
            NextLine();
        }
    }

    public override void HandleQuestion(int ans)
    {
        if (ans == 0)
        {
            kvl++;
        }
        else if(ans == 1)
        {
            slum++;
        }
        else
        {
            guard++;
        }
        if (kvl + slum + guard == 4)
            checkFactionQuest();
        NextLine();
    }

    public void checkFactionQuest()
    {
        if (kvl > 1)
            state = State.kvl;
        else if (slum > 1)
            state = State.slum;
        else
            state = State.guard;
    }

    public override void NextLine()
    {
        switch (state)
        {
            case State.greet:
                manager.ST("Welcome aboard the Soaring Phallus! My name is Silamarik, the captain of this 'beaut.\n Soon we'll be arriving in Junk City, the biggest city around these parts.");
                state = State.askName;
                break;
            case State.askName:
                inputField.gameObject.SetActive(true);
                manager.ST("Since it's your first time here, I'd like to ask a few questions. What is your name?");
                break;
            case State.question1:
                node = new DialogNode(PlayerManager.Instance.Stats.Name + ", that is a fine name indeed. If you don't mind me asking, why are you heading towards Junk City?", "Knowledge", "Money", "To protect others");
                HandleNode(node);
                state = State.question2;
                break;
            case State.question2:
                node = new DialogNode("What did you do before coming here?", "Study", "Drink vodka", "Work");
                HandleNode(node);
                state = State.question3;
                break;
            case State.question3:
                node = new DialogNode("How do you handle conflicts with others?", "I reason with them", "Everybody who crosses me will pay", "I rely on the law");
                HandleNode(node);
                state = State.question4;
                break;
            case State.question4:
                node = new DialogNode("Tell me about your family lineage.", "My parents were scholars", "I'm an orphan", "I hail from a military family.");
                HandleNode(node);
                break;
            case State.kvl:
                manager.ST("Sounds to me like you might want to check out the League of the Three Wizards. It's an organisation that does magical research.");
                kvlIntroQuest = new KVLIntro();
                QuestManager.Instance.AddQuest(kvlIntroQuest);
                Inventory.Instance.AddItemToInventory(starterWeapons[0]);
                state = State.lastline;
                break;
            case State.slum:
                manager.ST("I heard some people in the slums are offering work, if you're interested.");
                slumIntroQuest = new SlumIntro();
                QuestManager.Instance.AddQuest(slumIntroQuest);
                Inventory.Instance.AddItemToInventory(starterWeapons[1]);
                state = State.lastline;
                break;
            case State.guard:
                manager.ST("The town guard always needs new recruits, I think you'd fit right in.");
                guardIntroQuest = new GuardIntro();
                QuestManager.Instance.AddQuest(guardIntroQuest);
                Inventory.Instance.AddItemToInventory(starterWeapons[2]);
                state = State.lastline;
                break;
            case State.lastline:
                manager.ST("Well, it was fun talking to you. We'll be arriving in just a moment, you'd better get ready.");
                state = State.end;
                break;
            case State.end:
                manager.endConvo();
                StartCoroutine(SceneFader.Instance.FadeAndLoadScene(SceneFader.FadeDirection.In, "Port"));
                state = State.greet;
                break;
                
        }
            
    }  
}
