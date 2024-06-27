using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    public EnemyCreate enemyCreate;
    public PlayerMovement player;
    public float distanceFromPlayer;
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0.0f, 3.0f);
    }

    void spawnEnemy()
    {
        GameObject enemyInstance = enemyCreate.getEnemy();

        Vector2 playerLocation = player.getPlayerLocation();

        // Generates a random angle in radians from 0 to 360
        float randomRads = Random.Range(0f, Mathf.PI * 2);

        float offsetX = Mathf.Cos(randomRads) * distanceFromPlayer;
        float offsetY = Mathf.Sin(randomRads) * distanceFromPlayer;

        // Generates random location based on player location, random angle, and distanceFromPlayer
        Vector2 spawnLocation = playerLocation + new Vector2(offsetX, offsetY);
        Instantiate(enemyInstance, spawnLocation, Quaternion.identity);


    }
}
