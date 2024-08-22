using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibilityFlicker : MonoBehaviour
{
    [SerializeField] private int flickerAmount = 50;
    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private PlayerHealth playerHealth;

    public void invincibilityFlicker()
    {
        InvokeRepeating(nameof(spriteFlicker), 0f, playerHealth.secondsInvincible / flickerAmount);
        Invoke(nameof(cancelFlicker), playerHealth.secondsInvincible);
    }

    private void spriteFlicker()
    {
        if (playerSprite.enabled == true)
        {
            playerSprite.enabled = false;
        }
        else
        {
            playerSprite.enabled = true;
        }
    }

    private void cancelFlicker()
    {
        CancelInvoke(nameof(spriteFlicker));
        playerSprite.enabled = true;
    }
}
