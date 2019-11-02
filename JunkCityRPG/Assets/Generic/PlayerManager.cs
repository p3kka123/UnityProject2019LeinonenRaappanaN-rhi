using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

   

    private static PlayerManager _instance;
    public static PlayerManager Instance { get { return _instance; } }

    private PlayerStats stats;
    public PlayerStats Stats { get => stats; set => stats = value; }

    // Start is called before the first frame update
    void Awake()
    {
        if(_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
        DontDestroyOnLoad(this);

        if(stats == null) {
            stats = new PlayerStats(10,10,10);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
