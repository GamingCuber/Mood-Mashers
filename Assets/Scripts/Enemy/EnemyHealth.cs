using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 2f;
    private PlayerShoot playerShoot;
    public EnemyDropXP enemyXPManager;

    void Start()
    {
        // This line gets the player object, gets the PlayerShoot script, and then accesses the playerDamage public field
        playerShoot = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {
            float playerDamage = playerShoot.playerDamage;
            // Subtracts enemy health
            health -= playerDamage;
        }
        else if (objectLayer == LayerMask.NameToLayer("Rocket"))
        {
            var rocketDamage = GameObject.FindWithTag("Rocket").GetComponent<TargetRandomEnemy>().rocketDamage;
            health -= rocketDamage;
            Destroy(collision.gameObject);
        }

        if (health <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        enemyXPManager.dropXP();
        Destroy(gameObject);
    }
}
