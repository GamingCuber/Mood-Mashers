using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 2f;


    void FixedUpdate()
    {
        if (health <= 0)
        {
            killEnemy();
        }
    }


    private void killEnemy()
    {
        Debug.Log("Destroyed Enemy");
        Destroy(gameObject);
    }
}
