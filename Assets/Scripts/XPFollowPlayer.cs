using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPFollowPlayer : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float distanceUntilFollow;
    [SerializeField] private Rigidbody2D XPBody;
    [SerializeField] private float followSpeed;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        Vector2 playerLocation = player.transform.position;
        float distanceFromPlayer = Vector2.Distance(playerLocation, transform.position);
        if (distanceFromPlayer <= distanceUntilFollow)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation, followSpeed * Time.deltaTime);
        }
        else
        {
            XPBody.velocity = Vector2.zero;
            XPBody.angularVelocity = 0f;
        }
    }
}
