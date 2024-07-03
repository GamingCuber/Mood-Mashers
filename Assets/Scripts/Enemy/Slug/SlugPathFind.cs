using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugPathFind : MonoBehaviour
{

    [SerializeField] private float speedWhenPassive;
    [SerializeField] private float speedWhenAngry;
    [SerializeField] private float secondsUntilAngry;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = speedWhenPassive;
        Invoke(nameof(makeAngry), secondsUntilAngry);
    }

    // Update is called once per frame
    void Update()
    {
        // Gets the Player object
        var player = GameObject.FindGameObjectWithTag("Player");

        // Applies movement towards the enemy to move towards the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, currentSpeed * Time.deltaTime);
    }
    private void makeAngry()
    {
        currentSpeed = speedWhenAngry;
    }
}
