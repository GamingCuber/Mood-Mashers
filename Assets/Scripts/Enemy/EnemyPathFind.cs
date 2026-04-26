using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFind : MonoBehaviour
{
    public float followSpeed = 5f;
    float stunedTime = 0.8f;

    // Update is called once per frame
    void Update()
    {
        // Gets the Player object
        var player = GameObject.FindGameObjectWithTag("Player");

        // Applies movement towards the enemy to move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        LayerMask objectLayer = collision.gameObject.layer;
        
        // Checks if the Enemy gets hit by an attack by the player
        if (objectLayer == LayerMask.NameToLayer("Attack"))
        {
            followSpeed = 0f;
            StartCoroutine(stunTime());

        }
        else if (objectLayer == LayerMask.NameToLayer("Rocket"))
        {
            followSpeed = 0f;
            StartCoroutine(stunTime());
        }
    }

    IEnumerator stunTime()
    {
        yield return new WaitForSeconds(stunedTime);
        followSpeed = 1.5f;
    }
}
