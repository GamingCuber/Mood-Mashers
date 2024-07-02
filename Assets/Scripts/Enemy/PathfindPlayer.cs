using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindPlayer : MonoBehaviour
{
    public float followSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Gets the Player object
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Calculates the angel at which to face the enemy towards the player
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Applies movement towards the enemy to move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
