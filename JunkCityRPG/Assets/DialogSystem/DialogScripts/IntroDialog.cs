using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroDialog : Dialog
{


    private int dialogs;
    private int currentDialog = 0;


    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.show(this);
    }

    public override void SetManager(DialogManager manager) {
        //this.manager = manager;
    }

    override public void NextLine() {
        print("next line");
        switch (currentDialog) {
            case 0:
                DialogManager.Instance.ST("You have boarded a ship bound to Junk City. What brings you to this cesspool, only you know.");
                currentDialog++;
                break;
            case 1:
                DialogManager.Instance.ST("The journey has been arduous, but the ship's captain has been very accommodating.");
                currentDialog++;
                break;
            case 2:
                DialogManager.Instance.ST("The days have been slow and you have spent them on the ships deck, watching the clouds roll by.");
                currentDialog++;
                break;
            case 3:
                DialogManager.Instance.ST("As the final evening of your journey is approaching, the captain invites you to his quarters.");
                string[] choiceText = new string[2];
                choiceText[0] = "Enter.";
                DialogManager.Instance.Question(1,choiceText);                
                break;
        }
    }

    override public void HandleQuestion(int ans) {
        DialogManager.Instance.endConvo();
        SceneManager.LoadScene("IntroScene");
    }
}
