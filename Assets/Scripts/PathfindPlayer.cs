using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindPlayer : MonoBehaviour
{
    public GameObject player;
    public float followSpeed = 5f;
    private float distanceFromPlayer;

    // Update is called once per frame
    void Update()
    {
        distanceFromPlayer = Vector2.Distance(transform.position, player.transform.position);

        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
