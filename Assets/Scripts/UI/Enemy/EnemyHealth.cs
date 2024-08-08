using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float health = 2f;
    private float playerDamage;
    private Animator enemyAnimator;
    private Collider2D enemyCollider;
    public EnemyDropXP enemyXPManager;

    void Start()
    {
        // This line gets the player object, gets the PlayerShoot script, and then accesses the playerDamage public field
        playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().playerDamage;

        enemyAnimator = gameObject.GetComponent<Animator>();
        enemyCollider = gameObject.GetComponent<Collider2D>();
    }

    public void damageEnemy(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyCollider.enabled = false;
            enemyXPManager.dropXP();
            enemyAnimator.SetTrigger("isDead");
            Invoke(nameof(killEnemy), 2f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        enemyAnimator.SetTrigger("isHurt");
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {

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
            enemyCollider.enabled = false;
            enemyXPManager.dropXP();
            enemyAnimator.SetTrigger("isDead");
            Invoke(nameof(killEnemy), 2f);
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }
}
