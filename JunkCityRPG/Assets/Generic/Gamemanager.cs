﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private static Gamemanager _instance;

    public static Gamemanager Instance { get { return _instance; } }

    public GameState CurrentState { get => currentState; 
        set {
            lastState = currentState;
            currentState = value;
        }
    }

    public GameState LastState { get => lastState;}

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

    // Update is called once per frame
    void Update()
    {
        
    }
}
