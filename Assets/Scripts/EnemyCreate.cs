using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    // Returns an instance of the enemy prefab
    public GameObject getEnemy()
    {
        return Instantiate(gameObject);
    }

}
