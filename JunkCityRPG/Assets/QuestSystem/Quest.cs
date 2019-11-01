using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{

    protected bool completionState;
    protected string questName;
    protected int currentPhase = 0;

    protected Dictionary<int, QuestPhase> questPhases;

    protected int phaseIndex = 0;

    //public Quest(string _questName) {
    //    questName = _questName;
    //}

    public string GetQuestName() {
        return questName;
    }

    public virtual void CompleteQuest() {
        completionState = true;
        QuestManager.Instance.CompleteQuest(this);
    }

    public void AddQuestPhase(QuestPhase phase, int index) {
        questPhases.Add(phaseIndex, phase);
        //phaseIndex++;
    }

    public List<QuestPhase> GetCurrentPhases() {
        List<QuestPhase> currentPhases = new List<QuestPhase>();

        foreach(KeyValuePair<int, QuestPhase> phase in questPhases) {
            if(phase.Key == currentPhase)
                currentPhases.Add(phase.Value);
        }

        return currentPhases;
    }


    public class QuestPhase
    {
        private string phaseDescription;
        private bool completesQuest;

        public QuestPhase(string desc, bool complete) {
            PhaseDescription = desc;
            CompletesQuest = complete;
        }

        public string PhaseDescription { get => phaseDescription; set => phaseDescription = value; }
        public bool CompletesQuest { get => completesQuest; set => completesQuest = value; }
    }

}
