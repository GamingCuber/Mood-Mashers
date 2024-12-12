using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyKillTextUpdater : MonoBehaviour
{
    private TMP_Text enemyText;
    private int enemiesKilled = 0;
    void Start()
    {
        enemyText = GetComponent<TMP_Text>();
        enemyText.text = "Enemies Killed: 0";
    }

    public void updateText()
    {
        enemiesKilled++;
        enemyText.text = "Enemies Killed: " + enemiesKilled;

    }
}
