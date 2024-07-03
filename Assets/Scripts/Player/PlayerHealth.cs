using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 20f;
    public bool isInvincible = false;
    [SerializeField] private float secondsInvincible;
    [SerializeField] private Collider2D PlayerCollider;
    // Helper function that damages the player by a given amount "damage"
    public void damagePlayer(float damage)
    {
        isInvincible = true;
        Invoke(nameof(removeInvincibility), secondsInvincible);
        health -= damage;
        if (health < 0)
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
