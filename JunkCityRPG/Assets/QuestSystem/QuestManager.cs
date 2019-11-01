using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private static QuestManager _instance;

    public static QuestManager Instance { get { return _instance; } }


    private List<Quest> activeQuests = new List<Quest>();

    private List<Quest> completedQuests = new List<Quest>();

    private void Awake() {
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
        if(Input.GetKeyDown(KeyCode.J)) {
            //open journal
            foreach(Quest quest in activeQuests) {
                print(quest.GetQuestName());
            }
        }
    }

    public void AddQuest(Quest quest) {
        activeQuests.Add(quest);
    }

    public void CompleteQuest(Quest quest) {
        activeQuests.Remove(quest);
        completedQuests.Add(quest);
    }

}
