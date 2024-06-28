using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public EnemyHealth enemyHealth;
    public float enemyDamage = 10f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        if (objectLayer == LayerMask.NameToLayer("Player"))
        {
            playerHealth.damagePlayer(enemyDamage);
            Destroy(gameObject);

        }
        else if (objectLayer == LayerMask.NameToLayer("WaveAttack"))
        {

        }
    }

}
