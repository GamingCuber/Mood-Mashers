using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarManager : MonoBehaviour
{
    public PlayerXPManager playerXP;
    public Image XPBar;

    // Update is called once per frame
    void Update()
    {
        updateBar();
    }
    public void updateBar()
    {
        float fillAmount = playerXP.currentAmount / playerXP.amountUntilNextLevel;
        XPBar.fillAmount = fillAmount;
    }
}
