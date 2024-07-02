using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class XPFollowPlayer : MonoBehaviour
{
    public bool hasHit = false;
    public float distanceUntilFollow;
    [SerializeField] private CapsuleCollider2D XPCollider;
    [SerializeField] private float forceFromPlayer;
    [SerializeField] private float distanceFromPlayer;
    [SerializeField] private Rigidbody2D XPBody;
    [SerializeField] private float acceleration;
    [SerializeField] private float maxSpeed;

    private GameObject player;

    private float currentSpeed = 0f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 playerLocation = player.transform.position;
        float distanceFromPlayer = Vector2.Distance(playerLocation, transform.position);
        // If the player hasn't hit the XP orb yet
        if (!hasHit)
        {
            if (distanceFromPlayer <= distanceUntilFollow)
            {
                accelerateTowardsPlayer(playerLocation);
            }
            else
            {
                XPBody.velocity = Vector2.zero;
                XPBody.angularVelocity = 0f;
            }
        }
        // If the player has already hit the XP orb
        else
        {
            accelerateTowardsPlayer(playerLocation);
        }

    }
    // Function that accelerates XP towards the player when close enough
    private void accelerateTowardsPlayer(Vector2 playerLocation)
    {
        currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, currentSpeed * Time.deltaTime);
    }
    // Function that sends the XP away from the player, before it hurtles back
    public void applyForceAway()
    {
        // Disables the collider to prevent any odd collisions from occurring
        XPCollider.enabled = false;
        System.Random random = new System.Random();
        // Gets a random angle from 0 to 360
        float angle = (float)random.NextDouble() * 360;

        float angleToRadians = angle * Mathf.Deg2Rad;
        // Uses that angle to get a Vector2 a certain angle and distance away from the player
        float X = Mathf.Cos(angleToRadians) * distanceFromPlayer;
        float Y = Mathf.Sin(angleToRadians) * distanceFromPlayer;

        Vector2 direction = new Vector2(X, Y);
        // Applies a force based on that vector
        XPBody.AddForce(direction * forceFromPlayer, ForceMode2D.Impulse);
        // Tracks whether the player has interacted with the orb
        hasHit = true;
        // Reenables collisions after 0.1 seconds
        Invoke(nameof(enableCollisions), 0.1f);
    }
    // Helper function that just enables collisions again
    private void enableCollisions()
    {
        XPCollider.enabled = true;
    }
}
