using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJournalStatsInvController : MonoBehaviour
{
    private int mode = 0;

    private StatPanel stats;
    private JournalPanel journal;
    private Inventory inventory;
    [SerializeField]
    private Button statButton;
    [SerializeField]
    private Button invButton;
    [SerializeField]
    private Button jButton;

    public int Mode { get => mode; set => mode = value; }

    // Start is called before the first frame update
    void Start()
    {
        journal = GetComponentInChildren<JournalPanel>();
        stats = GetComponentInChildren<StatPanel>();
        inventory = GetComponentInChildren<Inventory>();
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        inventory.OpenInventory();
    }

    // Update is called once per frame
    //void Update()
    //{
    //if (Input.GetKeyDown(KeyCode.N))
    //gameObject.SetActive(!gameObject.activeInHierarchy);
    //if (gameObject.activeSelf) LoadTabContents(mode);
    //}

    public void LoadTabContents()
    {
        if (Mode == 2) inventory.OpenInventory();
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
            inventory.OpenInventory();
        }
    }

    public void LoadTabContents(int _mode)//its shit tabs get fuxked up
    {
        if (Mode == 2) inventory.OpenInventory();
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
            inventory.OpenInventory();
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
    }

}
