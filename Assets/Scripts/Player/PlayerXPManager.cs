using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXPManager : MonoBehaviour
{

    public int amountUntilNextLevel = 1;
    private int currentAmount = 0;
    private int currentLevel = 1;

    public void addXP(int XPAmount)
    {
        currentAmount += XPAmount;
        if (currentAmount >= amountUntilNextLevel)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        currentAmount = 0;
        currentLevel++;

    }

}
