using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Unity.Mathematics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class TargetRandomEnemy : MonoBehaviour
{
    [SerializeField] private float homingSpeed;
    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private Rigidbody2D rocketBody;
    [SerializeField] private GameObject rocketExplosion;
    private Vector2 randomlySelectedLocation;
    private Vector2 playerLocation;

    public void getLocation()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var random = new System.Random();
        // Gets the player location
        playerLocation = player.transform.position;
        // Gets a random angle from 0 to basically 360
        var angle = (float)random.NextDouble() * 360;

        var angleToRadians = angle * Mathf.Deg2Rad;

        // Uses angleToRadians to calculate x and y offsets from the player
        var offsetX = Mathf.Cos(angleToRadians) * distanceFromPlayer;
        var offsetY = Mathf.Sin(angleToRadians) * distanceFromPlayer;

        // Uses the offsets to calculate a spawn position for the enemy
        randomlySelectedLocation = playerLocation + new Vector2(offsetX, offsetY);

    }

    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomlySelectedLocation, homingSpeed * Time.fixedDeltaTime);
        // If the rocket has reached its destination
        if (transform.position.Equals(randomlySelectedLocation))
        {
            Instantiate(rocketExplosion, randomlySelectedLocation, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Just rotates the rocket towards where it wants to go
        float angle = Mathf.Atan2(randomlySelectedLocation.y - transform.position.y, randomlySelectedLocation.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new UnityEngine.Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 20 * Time.deltaTime);
    }
}
