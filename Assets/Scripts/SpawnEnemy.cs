using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject enemy;
    public float distanceFromPlayer = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(spawnEnemy), 0.0f, 5.0f);
    }

    private void spawnEnemy()
    {
        System.Random random = new System.Random();
        // Gets the player location
        Vector2 playerLocation = player.transform.position;
        // Gets a random angle from 0 to basically 360
        float angle = (float)random.NextDouble() * 360;

        float angleToRadians = angle * Mathf.Deg2Rad;

        // Uses angleToRadians to calculate x and y offsets from the player
        float offsetX = Mathf.Cos(angleToRadians) * distanceFromPlayer;
        float offsetY = Mathf.Sin(angleToRadians) * distanceFromPlayer;

        // Uses the offsets to calculate a spawn position for the enemy
        Vector2 spawnPosition = playerLocation + new Vector2(offsetX, offsetY);
        Instantiate(enemy, spawnPosition, Quaternion.identity);


    }


}
