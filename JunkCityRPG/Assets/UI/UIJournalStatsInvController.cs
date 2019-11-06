using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIJournalStatsInvController : MonoBehaviour
{
    private int mode = 0;

    private StatPanel stats;
    private JournalPanel journal;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        journal = GetComponentInChildren<JournalPanel>();
        stats = GetComponentInChildren<StatPanel>();
        inventory = GetComponentInChildren<Inventory>();
    }

    // Update is called once per frame
    //void Update()
    //{
        //if (Input.GetKeyDown(KeyCode.N))
            //gameObject.SetActive(!gameObject.activeInHierarchy);
        //if (gameObject.activeSelf) LoadTabContents(mode);
    //}

    public void LoadTabContents(int _mode)
    {
        if(mode == 2) inventory.OpenInventory();
        mode = _mode;
        if(mode == 0)
        {
            stats.PrintStats();
        }else if(mode == 1)
        {
            journal.PrintQuests();
        }else if(mode == 2)
        {
            inventory.OpenInventory();
        }
    }

}
