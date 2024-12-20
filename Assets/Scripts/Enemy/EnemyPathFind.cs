using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFind : MonoBehaviour
{
    public float followSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Gets the Player object
        var player = GameObject.FindGameObjectWithTag("Player");

        // Applies movement towards the enemy to move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    }
}
