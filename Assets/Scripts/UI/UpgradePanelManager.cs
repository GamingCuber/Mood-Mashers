using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
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


    private List<int> randomIndexes()
    {
        var indexes = new List<int>();
        var numberOfUpgrades = Enum.GetValues(typeof(LevelUpManager.LevelUpgrades)).Length;
        for (var i = 0; i < numberOfUpgrades - 1; i++)
        {
            indexes.Add(i);
        }
        var random = new System.Random();
        // Just shuffles the index list so the order is random
        indexes = indexes.OrderBy(i => random.Next()).ToList();
        return indexes.GetRange(0, 3);
    }
    private void setButtonText()
    {

        var indexes = randomIndexes();

        firstButtonText.SetText(upgradeTexts[indexes[0]]);
        secondButtonText.SetText(upgradeTexts[indexes[1]]);
        thirdButtonText.SetText(upgradeTexts[indexes[2]]);

        firstButtonImage.sprite = upgradeImages[indexes[0]];
        secondButtonImage.sprite = upgradeImages[indexes[1]];
        thirdButtonImage.sprite = upgradeImages[indexes[2]];

        indexes.Clear();

    }



    private void Awake()
    {
        PauseManager = GetComponent<PauseMenuManager>();
    }

    public void OpenPanel()
    {
        setButtonText();
        PauseManager.pauseGame();
        panel.SetActive(true);
    }

    public void ClosePanel()
    {
        PauseManager.resumeGame();
        panel.SetActive(false);
    }

}
