using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GuardIntro : Quest
{

    public GuardIntro()
    {
        questName = "It ain't much, but it's honest work";
        AddQuestPhase(new QuestPhase("Ask a guard to find where the town watch is", 0, false));
        AddQuestPhase(new QuestPhase("Talk to sergeant Paul", 1, false));
    }

    public void FindWatch()
    {
        currentPhase = 1;
    }

    public void TalkPaul()
    {
        CompleteQuest();
    }

}
