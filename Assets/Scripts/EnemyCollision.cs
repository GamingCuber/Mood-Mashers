using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public PlayerHealth playerHealthManager;

    void OnTriggerEnter2D(Collider2D collider)
    {
        LayerMask objectLayer = collider.gameObject.layer;
        if (objectLayer == LayerMask.NameToLayer("Player"))
        {
            playerHealthManager.damagePlayer(25);
            Debug.Log("Attacked Player");
        }
    }

}
