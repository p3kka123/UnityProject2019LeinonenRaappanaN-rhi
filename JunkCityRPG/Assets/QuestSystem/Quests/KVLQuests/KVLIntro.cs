using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KVLIntro : Quest
{

    public KVLIntro()
    {
        questName = "Three wise men";
        AddQuestPhase(new QuestPhase("Ask the lobbyist at the league for work", 0, false));
    }

    public void TalkLobbyist()
    {
        CompleteQuest();
    }

}
