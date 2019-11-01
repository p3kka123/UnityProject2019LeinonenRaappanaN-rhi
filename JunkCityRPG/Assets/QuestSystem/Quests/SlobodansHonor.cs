using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlobodansHonor : Quest
{

    private bool gaveSlobodanCyanide;

    public SlobodansHonor(string _questName) {
        questName = _questName;

        AddQuestPhase(new QuestPhase("Find cyanide for Slobodan", false), 0);
        AddQuestPhase(new QuestPhase("Report Slobodan to authorities",false),0);
        AddQuestPhase(new QuestPhase("Attend Slobodans trial",false),1);
    }


    public void GiveCyanide() {
        gaveSlobodanCyanide = true;
        currentPhase = 1;
    }

    public void AttendedTrial() {
        CompleteQuest();
    }

}
