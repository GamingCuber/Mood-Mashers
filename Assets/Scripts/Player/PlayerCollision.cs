using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public PlayerHealth playerHealth;
    public PlayerXPManager playerXPManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        // If the player hits an enemy
        if (objectLayer == LayerMask.NameToLayer("Enemy"))
        {
            if (!playerHealth.isInvincible)
            {
                float enemyDamage = collision.gameObject.GetComponent<EnemyDamage>().damage;
                playerHealth.damagePlayer(enemyDamage);
            }
        }
        else if (objectLayer == LayerMask.NameToLayer("Experience"))
        {
            var XPInstanceManager = collision.gameObject.GetComponent<XPFollowPlayer>();
            if (XPInstanceManager.hasHit)
            {

                playerXPManager.addXP(2);
                Destroy(collision.gameObject);
            }
            else
            {
                XPInstanceManager.applyForceAway();
            }

        }
    }
}
