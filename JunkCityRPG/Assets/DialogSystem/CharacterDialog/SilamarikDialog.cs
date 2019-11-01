using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SilamarikDialog : Dialog
{
    [SerializeField]
    private PlayerCombat playerCombat;
    [SerializeField]
    private InputField inputField;
    DialogManager manager;
    State state;

    public enum State
    {
        greet,
        askName,
        askName2,
        info,
        quest,
        end,
    }

    private void Update()
    {
        if(state == State.askName && Input.GetKeyDown(KeyCode.KeypadEnter) && inputField.text.Length != 0)
        {
            inputField.gameObject.SetActive(false);
            playerCombat.Stats.Name = inputField.text;
            state = State.askName2;
            NextLine();
        }
    }

    public override void HandleQuestion(int ans)
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
                manager.ST("What is your name?");
                break;
            case State.askName2:
                manager.ST(playerCombat.Stats.Name + ", that is a fine name indeed");
                state = State.end;
                break;
            case State.end:
                manager.endConvo();
                state = State.greet;
                break;
                
        }
            
    }

    public override void SetManager(DialogManager manager)
    {
        this.manager = manager;
    }
}
