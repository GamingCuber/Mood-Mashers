using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerXPManager : MonoBehaviour
{

    public float amountUntilNextLevel = 1;
    public float currentAmount = 0;
    private int currentLevel = 1;

    [SerializeField] private XPBarManager XPBar;
    [SerializeField] private UpgradePanelManager UpgradePanel;
    
    public void addXP(int XPAmount)
    {
        currentAmount += XPAmount;
        XPBar.updateBar();
        if (currentAmount >= amountUntilNextLevel)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        UpgradePanel.OpenPanel();
        currentAmount = 0;
        currentLevel++;

    }

}
