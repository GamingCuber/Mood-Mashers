using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] LevelUpManager levelUps;
    [SerializeField] Sprite[] upgradeImages;
    [SerializeField] string[] upgradeTexts;

    PauseMenuManager PauseManager;


    public TMP_Text firstButtonText;
    public TMP_Text secondButtonText;
    public TMP_Text thirdButtonText;

    public Image firstButtonImage;
    public Image secondButtonImage;
    public Image thirdButtonImage;
    public Button firstButton;
    public Button secondButton;
    public Button thirdButton;
    private Array levelUpgrades;
    private List<int> indexes;

    void Start()
    {
        fillUpgradesList();
        firstButton.onClick.AddListener(delegate { onLevelUpClick(firstButton); });
        secondButton.onClick.AddListener(delegate { onLevelUpClick(secondButton); });
        thirdButton.onClick.AddListener(delegate { onLevelUpClick(thirdButton); });
    }
    private void fillUpgradesList()
    {
        levelUpgrades = Enum.GetValues(typeof(LevelUpManager.LevelUpgrades));
    }

    private List<int> randomIndexes()
    {
        var indexes = new List<int>();
        var numberOfUpgrades = Enum.GetValues(typeof(LevelUpManager.LevelUpgrades)).Length;
        for (var i = 0; i < numberOfUpgrades - 1; i++)
        {
            // Add Logic that checks if the value is not apart of the completed upgrades list 8/1/2024
            indexes.Add(i);
        }
        var random = new System.Random();   
        // Just shuffles the index list so the order is random
        indexes = indexes.OrderBy(i => random.Next()).ToList();
        return indexes.GetRange(0, 3);
    }
    private void setButtonText()
    {

        indexes = randomIndexes();

        firstButtonText.SetText(upgradeTexts[indexes[0]]);
        secondButtonText.SetText(upgradeTexts[indexes[1]]);
        thirdButtonText.SetText(upgradeTexts[indexes[2]]);

        firstButtonImage.sprite = upgradeImages[indexes[0]];
        secondButtonImage.sprite = upgradeImages[indexes[1]];
        thirdButtonImage.sprite = upgradeImages[indexes[2]];


    }

    public void onLevelUpClick(Button clickedButton)
    {

        LevelUpManager.LevelUpgrades upgrade = LevelUpManager.LevelUpgrades.None;
        if (clickedButton == firstButton)
        {
            upgrade = (LevelUpManager.LevelUpgrades)levelUpgrades.GetValue(indexes[0]);
        }
        else if (clickedButton == secondButton)
        {
            upgrade = (LevelUpManager.LevelUpgrades)levelUpgrades.GetValue(indexes[1]);
        }
        else if (clickedButton == thirdButton)
        {
            upgrade = (LevelUpManager.LevelUpgrades)levelUpgrades.GetValue(indexes[2]);
        }
        indexes.Clear();

        levelUps.chooseLevelUp(upgrade);
        ClosePanel();
    }

    public void OpenPanel()
    {
        setButtonText();
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        Time.timeScale = 1f;
        panel.SetActive(false);
    }

}
