﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlumIntro : Quest
{

    public SlumIntro()
    {
        questName = "It ain't much, but it's dishonest work";
        AddQuestPhase(new QuestPhase("Ask the hobos in the slums to find work", 0, false));
        AddQuestPhase(new QuestPhase("Talk to Gold Jack", 1, false));
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
