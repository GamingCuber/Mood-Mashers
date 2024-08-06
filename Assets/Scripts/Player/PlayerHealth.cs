using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 20f;
    public float plushieHealth = 0f;
    public float maxPlushieHealth = 20f;
    public bool isInvincible = false;
    public PlushiePlayerFollow plushie;
    public PlushieBarManager plushieBar;
    public GameObject fullPlushieBar;
    [SerializeField] private float secondsInvincible;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private HealthBarManager healthBar;
    private bool isDead;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Helper function that damages the player by a given amount "damage"
    public void damagePlayer(float damage)
    {
        if (isDead == true) { return; }
        isInvincible = true;
        Invoke(nameof(removeInvincibility), secondsInvincible);
        // Checks whether plushie health is still there
        if (plushieHealth > 0.1f)
        {

            plushieHealth -= damage;
            Math.Round(plushieHealth);
            plushieBar.updateBar();
            // Checks if after taking plushie damage, whether plushie health is gone or not
            if (plushieHealth <= 0.1f)
            {
                fullPlushieBar.SetActive(false);
            }
        }
        // When there's no plushie health, subtracts from player health
        else
        {
            plushie.plushieRenderer.enabled = false;
            currentHealth -= damage;
            healthBar.updateBar();

            if (currentHealth < 0)
            {
                killPlayer();
            }
        }

    }

    void killPlayer()
    {
        GetComponent<PlayerGameOver>().GameOver();
        isDead = true;
    }
    private void removeInvincibility()
    {
        isInvincible = false;
    }
}
