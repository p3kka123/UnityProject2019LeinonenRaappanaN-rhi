using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalPanel : MonoBehaviour
{
    public GameObject questMenuItem;

    public  VerticalLayoutGroup grid;

    [SerializeField]
    private TextMeshProUGUI questDescriptionText;

    public SlobodansHonor Slobbis;

    private void ShowQuestDetail(Quest quest)
    {
        string printedText = "";
        foreach (Quest.QuestPhase questPhase in quest.GetCurrentPhases())
            printedText += questPhase.PhaseDescription + "\n\n";

        questDescriptionText.SetText(quest.GetQuestName() + "\n\n\n" + printedText);

    }

    public void PrintQuests()
    {
        foreach (Transform child in grid.transform)
        {
            Destroy(child.gameObject);
        }
        if (questDescriptionText == null) questDescriptionText = GetComponentInChildren<TextMeshProUGUI>();
        foreach(Quest quest in QuestManager.Instance.activeQuests)
        {
            GameObject menuItem = Instantiate(questMenuItem, grid.transform);
            menuItem.GetComponentInChildren<TextMeshProUGUI>().SetText(quest.GetQuestName());
            menuItem.GetComponent<Button>().onClick.AddListener(delegate { ShowQuestDetail(quest); });
        }
    }
}
