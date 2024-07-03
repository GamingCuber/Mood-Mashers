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
            playerHealth.damagePlayer(2.0f);
            Destroy(collision.gameObject);
        }
        else if (objectLayer == LayerMask.NameToLayer("Experience"))
        {
            var XPInstanceManager = collision.gameObject.GetComponent<XPFollowPlayer>();
            if (XPInstanceManager.hasHit)
            {

                playerXPManager.addXP(1);
                Destroy(collision.gameObject);
            }
            else
            {
                XPInstanceManager.applyForceAway();
            }

        }
    }

}
