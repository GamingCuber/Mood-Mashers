using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public PlayerMovement player;
    public EnemyCreate enemy;
    public float distanceFromPlayer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spawnEnemy), 0.0f, 5.0f);
    }

    private void spawnEnemy()
    {
        GameObject enemyInstance = enemy.getEnemy();
        System.Random random = new System.Random();

        Vector2 playerLocation = player.getPlayerLocation();
        // Gets a random angle from 0 to basically 360
        float angle = (float)random.NextDouble() * 359.99f;

        float angleToRadians = angle * Mathf.Deg2Rad;

        float offsetX = Mathf.Cos(angleToRadians) * distanceFromPlayer;
        float offsetY = Mathf.Sin(angleToRadians) * distanceFromPlayer;

        Vector2 spawnPosition = playerLocation + new Vector2(offsetX, offsetY);
        Instantiate(enemyInstance, spawnPosition, Quaternion.identity);


    }


}
