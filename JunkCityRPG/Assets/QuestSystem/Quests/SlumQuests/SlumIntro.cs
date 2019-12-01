using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumIntro : Quest
{

    public SlumIntro()
    {
        questName = "It ain't much, but it's dishonest work";
        AddQuestPhase(new QuestPhase("Ask around the slums to find work", 0, false));
        AddQuestPhase(new QuestPhase("Seek out SHIT headquarters",1,false));
        AddQuestPhase(new QuestPhase("Talk to Gold Jack", 2, false));
    }

    public void FindJack()
    {
        currentPhase = 1;
    }

    public void TalkJack()
    {
        CompleteQuest();
    }

}
