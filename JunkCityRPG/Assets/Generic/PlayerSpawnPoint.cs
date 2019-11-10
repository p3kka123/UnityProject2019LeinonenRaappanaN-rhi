using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{

    [SerializeField] private string previousScene;

    public string PreviousScene { get => previousScene; set => previousScene = value; }

    // Start is called before the first frame update
    void Awake()
    {
        Gamemanager.Instance.SpawnPoints.Add(this);
    }


    private void OnDestroy() {
        Gamemanager.Instance.SpawnPoints.Remove(this);
    }
    //// Update is called once per frame
    //void Update()
    //{

    //}
}
