using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;

    public static Gamemanager Instance { get { return _instance; } }


    private GameObject player;
    private GameObject inventoryGrid;
    private GameObject playerRightHandAnchor;
    private GameObject inventory;
    private GameObject attackHitBox;

    public GameState CurrentState { get => currentState; 
        set {
            lastState = currentState;
            currentState = value;
        }
    }

    public GameState LastState { get => lastState;}
    public GameObject Player { get => player; set => player = value; }
    public GameObject InventoryGrid { get => inventoryGrid; set => inventoryGrid = value; }
    public GameObject PlayerRightHandAnchor { get => playerRightHandAnchor; set => playerRightHandAnchor = value; }
    public GameObject Inventory { get => inventory; set => inventory = value; }
    public GameObject AttackHitBox { get => attackHitBox; set => attackHitBox = value; }

    public enum GameState
    {
        Normal,
        Dialog,
        Combat,
        Menu,
        Pause
    }

    private GameState lastState;
    private GameState currentState;

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        DontDestroyOnLoad(this);


    }

}
