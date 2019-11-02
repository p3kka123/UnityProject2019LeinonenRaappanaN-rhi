using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlobodansHonor : Quest
{

    private bool gaveSlobodanCyanide;
    private bool playerHasCyanide;

    public bool PlayerHasCyanide { get => playerHasCyanide; set => playerHasCyanide = value; }
    public bool GaveSlobodanCyanide { get => gaveSlobodanCyanide; set => gaveSlobodanCyanide = value; }

    public SlobodansHonor() {
        questName = "Slobodan's Honor";
        QuestPhase phase = new QuestPhase("Find cyanide for Slobodan",0,false);
        AddQuestPhase(phase);
        AddQuestPhase(new QuestPhase("Report Slobodan to authorities",0,false));
        AddQuestPhase(new QuestPhase("Attend Slobodans trial",1,false));
    }


    public void GiveCyanide() {
        gaveSlobodanCyanide = true;
        currentPhase = 1;
    }

    public void AttendedTrial() {
        CompleteQuest();
    }

}
