using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{

    protected bool completionState;
    protected string questName;
    protected int currentPhase = 0;

    protected Dictionary<int, QuestPhase> questPhases = new Dictionary<int, QuestPhase>();

    protected int dictionaryIndex = 0;

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

    public void AddQuestPhase(QuestPhase phase) {
        questPhases.Add(dictionaryIndex, phase);
        dictionaryIndex++;
    }

    public List<QuestPhase> GetCurrentPhases() {
        List<QuestPhase> currentPhases = new List<QuestPhase>();

        foreach(KeyValuePair<int, QuestPhase> phase in questPhases) {
            if(phase.Value.PhaseIndex == currentPhase)
                currentPhases.Add(phase.Value);
        }

        return currentPhases;
    }

    [System.Serializable]
    public class QuestPhase
    {
        private string phaseDescription;
        private bool completesQuest;
        private int phaseIndex;

        public QuestPhase(string desc,int index, bool complete) {
            PhaseDescription = desc;
            CompletesQuest = complete;
            PhaseIndex = index;
        }

        public string PhaseDescription { get => phaseDescription; set => phaseDescription = value; }
        public bool CompletesQuest { get => completesQuest; set => completesQuest = value; }
        public int PhaseIndex { get => phaseIndex; set => phaseIndex = value; }
    }

}
