using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatUpHandler : MonoBehaviour
{
    private PlayerStats tempStats = new PlayerStats(10,10,10);
    private StatPanel statPanel;
    private bool Started = false;
    private int gonapaska;

    public void OnStarted()
    {
        if (PlayerManager.Instance.Stats.StatPoints <= 0 && !Started)
        {
            gameObject.SetActive(false);
            return;
        }
        else if(!Started)
        {
            //print("onstarted !started, set tempstats");
            tempStats.StatPoints = PlayerManager.Instance.Stats.StatPoints;
            tempStats.Strength = PlayerManager.Instance.Stats.Strength;
            tempStats.Dexterity = PlayerManager.Instance.Stats.Dexterity;
            tempStats.Intelligence = PlayerManager.Instance.Stats.Intelligence;
            tempStats.Wisdom = PlayerManager.Instance.Stats.Wisdom;
            tempStats.Constitution = PlayerManager.Instance.Stats.Constitution;
            tempStats.Charisma = PlayerManager.Instance.Stats.Charisma;
            //tempStats = PlayerManager.Instance.Stats;
            statPanel = GetComponentInParent<StatPanel>();
            gonapaska = tempStats.StatPoints;
            gameObject.SetActive(true);
            Started = true;
        }
    }


    public void AddToStat(int index)
    {
        if (PlayerManager.Instance.Stats.StatPoints > 0)
        {
            switch (index)
            {
                case 1:
                    PlayerManager.Instance.Stats.Strength++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
                case 2:
                    PlayerManager.Instance.Stats.Dexterity++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
                case 3:
                    PlayerManager.Instance.Stats.Intelligence++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
                case 4:
                    PlayerManager.Instance.Stats.Wisdom++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
                case 5:
                    PlayerManager.Instance.Stats.Constitution++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
                case 6:
                    PlayerManager.Instance.Stats.Charisma++;
                    PlayerManager.Instance.Stats.StatPoints--;
                    break;
            }
        }
        print(Started);
        print(gonapaska);
        statPanel.PrintStats();
        print(tempStats.StatPoints);
    }

    public void RemoveFromStat(int index)
    {
        switch (index)
        {
            case 1:
                if (tempStats.Strength < PlayerManager.Instance.Stats.Strength)
                {
                    PlayerManager.Instance.Stats.Strength--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
            case 2:
                if (tempStats.Dexterity < PlayerManager.Instance.Stats.Dexterity)
                {
                    PlayerManager.Instance.Stats.Dexterity--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
            case 3:
                if (tempStats.Intelligence < PlayerManager.Instance.Stats.Intelligence)
                {
                    PlayerManager.Instance.Stats.Intelligence--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
            case 4:
                if (tempStats.Wisdom < PlayerManager.Instance.Stats.Wisdom)
                {
                    PlayerManager.Instance.Stats.Wisdom--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
            case 5:
                if (tempStats.Constitution < PlayerManager.Instance.Stats.Constitution)
                {
                    PlayerManager.Instance.Stats.Constitution--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
            case 6:
                if (tempStats.Charisma < PlayerManager.Instance.Stats.Charisma)
                {
                    PlayerManager.Instance.Stats.Charisma--;
                    PlayerManager.Instance.Stats.StatPoints++;
                }
                break;
        }
        statPanel.PrintStats();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        Started = false;
    }

    public void ResetButton()
    {
        PlayerManager.Instance.Stats.StatPoints = tempStats.StatPoints;
        PlayerManager.Instance.Stats.Strength = tempStats.Strength;
        PlayerManager.Instance.Stats.Dexterity = tempStats.Dexterity;
        PlayerManager.Instance.Stats.Intelligence = tempStats.Intelligence;
        PlayerManager.Instance.Stats.Wisdom = tempStats.Wisdom;
        PlayerManager.Instance.Stats.Constitution = tempStats.Constitution;
        PlayerManager.Instance.Stats.Charisma = tempStats.Charisma;

        tempStats.StatPoints = PlayerManager.Instance.Stats.StatPoints;
        tempStats.Strength = PlayerManager.Instance.Stats.Strength;
        tempStats.Dexterity = PlayerManager.Instance.Stats.Dexterity;
        tempStats.Intelligence = PlayerManager.Instance.Stats.Intelligence;
        tempStats.Wisdom = PlayerManager.Instance.Stats.Wisdom;
        tempStats.Constitution = PlayerManager.Instance.Stats.Constitution;
        tempStats.Charisma = PlayerManager.Instance.Stats.Charisma;

        statPanel.PrintStats();
    }

    public void Apply()
    {
        if(PlayerManager.Instance.Stats.StatPoints <= 0)
        {
            Close();
            return;
        }
        tempStats.StatPoints = PlayerManager.Instance.Stats.StatPoints;
        tempStats.Strength = PlayerManager.Instance.Stats.Strength;
        tempStats.Dexterity = PlayerManager.Instance.Stats.Dexterity;
        tempStats.Intelligence = PlayerManager.Instance.Stats.Intelligence;
        tempStats.Wisdom = PlayerManager.Instance.Stats.Wisdom;
        tempStats.Constitution = PlayerManager.Instance.Stats.Constitution;
        tempStats.Charisma = PlayerManager.Instance.Stats.Charisma;
    }

}
