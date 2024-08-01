using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlushieBarManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    [SerializeField] private Image plushieBar;

    void Start()
    {
        this.enabled = false;
    }

    public void updateBar()
    {
        float fillAmount = playerHealth.plushieHealth / playerHealth.maxPlushieHealth;
        plushieBar.fillAmount = fillAmount;
    }
}
