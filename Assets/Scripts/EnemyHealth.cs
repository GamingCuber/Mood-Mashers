using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 2f;
    private float playerDamage;

    void Start()
    {
        // This line gets the player object, gets the PlayerShoot script, and then accesses the playerDamage public field
        playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().playerDamage;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {
            // Subtracts enemy health
            health -= playerDamage;
            if (health <= 0)
            {
                killEnemy();
            }
        }
    }

    private void killEnemy()
    {
        Debug.Log("Destroyed Enemy");
        Destroy(gameObject);
    }
}
