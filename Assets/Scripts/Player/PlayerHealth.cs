using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 1f;
    public float plushieHealth = 0f;
    public float maxPlushieHealth = 20f;
    public bool isInvincible = false;
    public PlushiePlayerFollow plushie;
    public PlushieBarManager plushieBar;
    public GameObject fullPlushieBar;
    public float secondsInvincible;
    public Image plushieImage;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private HealthBarManager healthBar;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerInvincibilityFlicker playerInvincibility;
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
        playerInvincibility.invincibilityFlicker();
        playerAnimator.SetTrigger("isHurt");
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
            plushieImage.color = Color.gray;
            currentHealth -= damage;
            healthBar.updateBar();

            if (currentHealth < 0)
            {
                killPlayer();
            }
        }

    }

    public void healPlayer(float recovery)
    {
        currentHealth += recovery;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.updateBar();
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
