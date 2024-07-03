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
        var random = new System.Random();
        // Gets the player location
        Vector2 playerLocation = player.transform.position;
        // Gets a random angle from 0 to basically 360
        var angle = (float)random.NextDouble() * 360;

        var angleToRadians = angle * Mathf.Deg2Rad;

        // Uses angleToRadians to calculate x and y offsets from the player
        var offsetX = Mathf.Cos(angleToRadians) * distanceFromPlayer;
        var offsetY = Mathf.Sin(angleToRadians) * distanceFromPlayer;

        // Uses the offsets to calculate a spawn position for the enemy
        var spawnPosition = playerLocation + new Vector2(offsetX, offsetY);
        Instantiate(enemy, spawnPosition, Quaternion.identity);


    }


}
