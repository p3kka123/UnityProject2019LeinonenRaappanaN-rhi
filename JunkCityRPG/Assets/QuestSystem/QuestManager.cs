using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    private static QuestManager _instance;

    public static QuestManager Instance { get { return _instance; } }


    public List<Quest> activeQuests = new List<Quest>();

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

                List<Quest.QuestPhase> phases = quest.GetCurrentPhases();
                foreach(Quest.QuestPhase phase in phases) {
                    print("Objective: " + phase.PhaseDescription);
                }
            }
        }
    }

    public Quest FindQuest(string questName) {
        foreach(Quest quest in activeQuests) 
            if(quest.GetQuestName() == questName) 
                return quest;
        
        return null;
    }

    public void AddQuest(Quest quest) {
        activeQuests.Add(quest);
        Gamemanager.Instance.DisplayNotification("New quest: " + quest.GetQuestName());
    }

    public void CompleteQuest(Quest quest) {
        activeQuests.Remove(quest);
        completedQuests.Add(quest);
    }

}
