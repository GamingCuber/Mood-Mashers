using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    public int enemiesKilled = 0;
    public TextMeshProUGUI enemiesKilledText; 

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        UpdateEnemiesKilledText();
    }

    private void UpdateEnemiesKilledText()
    {
        if (enemiesKilledText != null)
        {
            enemiesKilledText.text = "Enemies Killed: " + enemiesKilled;
        }
    }
}
