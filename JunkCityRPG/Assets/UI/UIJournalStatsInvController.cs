using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJournalStatsInvController : MonoBehaviour
{
    private int mode = 0;

    private StatPanel stats;
    private JournalPanel journal;
    private FactionPanel factions;
    [SerializeField]
    private Button statButton;
    [SerializeField]
    private Button invButton;
    [SerializeField]
    private Button jButton;
    [SerializeField]
    private Button fButton;

    public int Mode { get => mode; set => mode = value; }

    // Start is called before the first frame update
    void Start()
    {
        factions = GetComponentInChildren<FactionPanel>();
        journal = GetComponentInChildren<JournalPanel>();
        stats = GetComponentInChildren<StatPanel>();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        Inventory.Instance.OpenInventory();
    }

    public void LoadTabContents()
    {
        if (Mode == 2) Inventory.Instance.OpenInventory();
        if (Mode == 0)
        {
            stats.PrintStats();
        }
        else if (Mode == 1)
        {
            journal.PrintQuests();
        }
        else if (Mode == 2)
        {
            Inventory.Instance.OpenInventory();
        }
        else if (Mode == 3)
        {
            factions.PrintFactions();
        }
    }

    public void LoadTabContents(int _mode)//its shit tabs get fuxked up
    {
        if (Mode == 2) Inventory.Instance.OpenInventory();
        Mode = _mode;
        if (Mode == 0)
        {
            stats.PrintStats();
        }
        else if (Mode == 1)
        {
            journal.PrintQuests();
        }
        else if (Mode == 2)
        {
            Inventory.Instance.OpenInventory();
        }
        else if (Mode == 3)
        {
            factions.PrintFactions();
        }
    }

    public void PressTab(int _mode)
    {
        if (_mode == 0)
        {
            statButton.onClick.Invoke();
        }
        else if (_mode == 1)
        {
            jButton.onClick.Invoke();
        }
        else if (_mode == 2)
        {
            invButton.onClick.Invoke();
        }
        else if (_mode == 3)
        {
            fButton.onClick.Invoke();
        }
    }

}
