using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 20f;
    public bool isInvincible = false;
    [SerializeField] private float secondsInvincible;
    [SerializeField] private Collider2D PlayerCollider;
    [SerializeField] private HealthBarManager healthBar;
    void Start()
    {
        currentHealth = maxHealth;
    }
    // Helper function that damages the player by a given amount "damage"
    public void damagePlayer(float damage)
    {
        isInvincible = true;
        healthBar.updateBar();
        Invoke(nameof(removeInvincibility), secondsInvincible);
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            killPlayer();
        }
    }

    void killPlayer()
    {
        gameObject.SetActive(false);
    }
    private void removeInvincibility()
    {
        isInvincible = false;
    }
}
