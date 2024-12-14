using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerXPManager : MonoBehaviour
{

    public float amountUntilNextLevel = 20;
    public float currentAmount = 0;
    public int currentLevel = 1;
    public GameObject eventSystem;
    [SerializeField] public float levelScaling = 1.1f;
    [SerializeField] private GameObject firstLevelUpButton;

    [SerializeField] private XPBarManager XPBar;
    [SerializeField] private UpgradePanelManager UpgradePanel;

    private void Start()
    {
        XPBar.SetLevelText(currentLevel);
    }

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
        eventSystem.GetComponent<EventSystem>().SetSelectedGameObject(firstLevelUpButton); ;
        UpgradePanel.OpenPanel();
        currentAmount = 0;
        currentLevel++;
        amountUntilNextLevel *= levelScaling;
        XPBar.SetLevelText(currentLevel);
    }



}
