using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class XPBarManager : MonoBehaviour
{
    public PlayerXPManager playerXP;
    public Image XPBar;
    [SerializeField] TMPro.TextMeshProUGUI levelText;
    public void updateBar()
    {
        float fillAmount = playerXP.currentAmount / playerXP.amountUntilNextLevel;
        XPBar.fillAmount = fillAmount;
    }

    public void SetLevelText(int currentLevel)
    {
       levelText.text = "Level:" + currentLevel.ToString();
    }
}
