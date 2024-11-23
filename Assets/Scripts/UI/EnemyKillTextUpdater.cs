using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyKillTextUpdater : MonoBehaviour
{
    public static int enemiesKilled = 0;
    private static TextMeshProUGUI enemyText;
    void Awake()
    {
        enemiesKilled = 0;
        enemyText = GetComponent<TextMeshProUGUI>();
        updateText();
    }

    public static void addEnemy()
    {
        enemiesKilled++;
        updateText();
    }

    private static void updateText()
    {
        enemyText.text = "Enemies Killed: " + enemiesKilled;
    }
}
