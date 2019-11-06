using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilamarikPortDialog : Dialog
{

    State state;

    [SerializeField] List<Weapon> starterWeapons = new List<Weapon>();
    private Weapon startWeapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public enum State
    {
        Greet,
        Kvl,
        Slum,
        Guard,
        Gift,
        Farewell,
        End
        
    }


    public override void NextLine() {
        switch(state) {
            case State.Greet:
                manager.ST("Well, we're finally here. Welcome to Junk City, " + PlayerManager.Instance.Stats.Name + ". " +
                    "It's a vile place, so you better watch your back lad!");
                if(QuestManager.Instance.FindQuest("It ain't much, but it's dishonest work") != null) {
                    startWeapon = starterWeapons[1];
                    state = State.Slum;
                } else if(QuestManager.Instance.FindQuest("Three wise men") != null) {
                    startWeapon = starterWeapons[0];
                    state = State.Kvl;
                } else {
                    startWeapon = starterWeapons[2];
                    state = State.Guard;
                }
                break;

            case State.Guard:
                manager.ST("As I mentioned earlier, the town guard is always hiring able men. The barracks is just past the city square, up north.");
                state = State.Gift;
                break;

            case State.Kvl:
                manager.ST("As I mentioned earlier, it sounds like you'd be interested in The League of Three Wizards. Their headquarters are at the city square, north of here.");
                state = State.Gift;
                break;

            case State.Slum:
                manager.ST("As I mentioned earlier, I've heard that there are some people in the slums offering work. You'll find the slums by heading east.");
                state = State.Gift;
                break;

            case State.Gift:
                manager.ST("Oh, and before I forget, here's a little token of gratitude for keeping me company on the journey. It ain't much but it might keep you safe on these streets.");
                Inventory.Instance.AddItemToInventory(startWeapon);
                Gamemanager.Instance.DisplayNotification("Received " + startWeapon.ItemName);
                state = State.Farewell;                
                break;

            case State.Farewell:
                manager.ST("Farewell and I wish you luck.");   
                state = State.End;
                break;

            case State.End:
                state = State.Farewell;
                manager.endConvo();
                break;
        }
    }

    public override void HandleQuestion(int ans) {
        throw new System.NotImplementedException();
    }

    
}
