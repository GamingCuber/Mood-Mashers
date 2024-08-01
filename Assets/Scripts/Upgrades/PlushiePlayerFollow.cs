using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class PlushiePlayerFollow : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private float followSpeed;
    [SerializeField] private float followDistance;
    [SerializeField] private Rigidbody2D plushieBody;
    public SpriteRenderer plushieRenderer;

    void Start()
    {
        plushieRenderer.enabled = false;
    }

    void Update()
    {
        var plushieLocation = transform.position;
        var playerLocation = player.transform.position;

        var distance = UnityEngine.Vector2.Distance(plushieLocation, playerLocation);

        if (distance > followDistance)
        {
            followPlayer();

        }
    }

    private void followPlayer()
    {
        transform.position = UnityEngine.Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
    }
}
