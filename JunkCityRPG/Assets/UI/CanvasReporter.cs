using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasReporter : MonoBehaviour
{
    [SerializeField] private UIJournalStatsInvController uiJSIController;
    [SerializeField] private GameObject inventoryGO;
    [SerializeField] private GameObject inventoryGrid;
    [SerializeField] private GameObject notification;
    [SerializeField] private GameObject tooltip;

    // Update is called once per frame
    void Awake()
    {
        Gamemanager.Instance.UiJSIcontroller = uiJSIController;
        Gamemanager.Instance.InventoryGrid = inventoryGrid;
        Gamemanager.Instance.Inventory = inventoryGO;
        Gamemanager.Instance.Notification = notification;
        Gamemanager.Instance.ToolTip = tooltip;
    }
}
