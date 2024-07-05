using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField] private Image healthBar;

    void Update()
    {
        updateBar();
    }

    public void updateBar()
    {
        float fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
        healthBar.fillAmount = fillAmount;
    }
}
