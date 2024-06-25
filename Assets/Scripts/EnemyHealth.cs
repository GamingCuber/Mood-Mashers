using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 2f;

    public void damageEnemy(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killEnemy();
        }
    }

    private void killEnemy()
    {
        Debug.Log("Enemy dies");
        Destroy(gameObject);
    }

}
