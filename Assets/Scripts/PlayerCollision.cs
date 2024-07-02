using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerHealth playerHealth;

    void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        // If the player hits an enemy
        if (objectLayer == LayerMask.NameToLayer("Enemy"))
        {
            playerHealth.damagePlayer(2.0f);
            Destroy(collision.gameObject);
        }
    }

}
