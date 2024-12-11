using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class EnemyHealth : MonoBehaviour
{

    public float health = 2f;
    private float playerDamage;
    private Animator enemyAnimator;
    private Collider2D enemyCollider;
    private EnemyPathFind enemyPathFind;
    private AudioManager audioManager;
    public EnemyDropItem enemyDropsManager;


    void Start()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
        enemyCollider = gameObject.GetComponent<Collider2D>();
        enemyPathFind = gameObject.GetComponent<EnemyPathFind>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void damageEnemy(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            enemyCollider.enabled = false;
            enemyPathFind.enabled = false;
            enemyDropsManager.dropItem();
            enemyAnimator.SetTrigger("isDead");
            var enemyTag = gameObject.tag;
            switch (enemyTag)
            {
                case "Slug":
                    audioManager.playSound(audioManager.slimeDeath);
                    break;
                case "Zombie":
                    audioManager.playSound(audioManager.zombieDeath);
                    break;
                case "Split":
                    audioManager.playSound(audioManager.splitDeath);
                    break;

            }
            Invoke(nameof(killEnemy), 1.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        enemyAnimator.SetTrigger("isHurt");
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {
            playerDamage = GameObject.FindWithTag("Player").GetComponent<PlayerShoot>().playerDamage;
            damageEnemy(playerDamage);
        }
        else if (objectLayer == LayerMask.NameToLayer("Rocket"))
        {
            var rocketDamage = GameObject.FindWithTag("RocketExplosion").GetComponent<RocketExplosionDamage>().rocketDamage;
            damageEnemy(rocketDamage);
        }
    }

    private void killEnemy()
    {
        Destroy(gameObject);
        GameManager.Instance.EnemyKilled();
    }
}

