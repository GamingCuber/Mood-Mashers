using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] LevelUpManager levelUps;

    PauseMenuManager PauseManager;

    public GameObject FirstLevelUpButton;
    public GameObject SecondLevelUpButton;

    public GameObject ThirdLevelUpButton;

    private List<LevelUpManager.LevelUpgrades> levelUpsList;
    private LevelUpManager.LevelUpgrades firstUpgrade;
    private LevelUpManager.LevelUpgrades secondUpgrade;
    private LevelUpManager.LevelUpgrades thirdUpgrade;


    private void generateUpgrades()
    {

        System.Array possibleLevelUps = Enum.GetValues(typeof(LevelUpManager.LevelUpgrades));
        System.Array indexes = randomIndexes(0, possibleLevelUps.Length - 1).ToArray();
        firstUpgrade = (LevelUpManager.LevelUpgrades)possibleLevelUps.GetValue((int)indexes.GetValue(0));
        secondUpgrade = (LevelUpManager.LevelUpgrades)possibleLevelUps.GetValue((int)indexes.GetValue(0));
        thirdUpgrade = (LevelUpManager.LevelUpgrades)possibleLevelUps.GetValue((int)indexes.GetValue(0));
    }

    private List<int> randomIndexes(int min, int max)
    {
        List<int> randomIndexes = new List<int>();
        System.Random random = new System.Random();
        int currentNumber = random.Next(min, max);
        for (int i = 0; i < 3; i++)
        {
            while (randomIndexes.Contains(currentNumber))
            {
                currentNumber = random.Next(min, max);
                if (!randomIndexes.Contains(currentNumber))
                {
                    randomIndexes.Add(currentNumber);
                }
            }
        }

        return randomIndexes;
    }
    private void setButtonText()
    {

    }

    private void Awake()
    {
        PauseManager = GetComponent<PauseMenuManager>();
    }

    public void OpenPanel()
    {
        PauseManager.pauseGame();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        PauseManager.resumeGame();
        panel.SetActive(false);
    }

}
